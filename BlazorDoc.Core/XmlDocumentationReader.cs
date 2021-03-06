using BlazorDoc.Models;
using LoxSmoke.DocXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.XPath;

namespace BlazorDoc.Components
{
    public class XmlDocumentationReader : IXmlDocumentationReader
    {
        DocXmlReader reader;

        bool referencedAsseblysLoaded;
        readonly List<Assembly> defaultAsseblies = new()
        {
            Assembly.GetAssembly(typeof(System.Object)),
            Assembly.GetAssembly(typeof(System.Type)),
            Assembly.GetAssembly(typeof(System.Reflection.TypeInfo)),
            Assembly.GetAssembly(typeof(System.IO.File)),
            Assembly.GetAssembly(typeof(System.Security.VerificationException)),
            Assembly.GetAssembly(typeof(System.Collections.IEnumerable)),
            Assembly.GetAssembly(typeof(System.Net.Http.HttpClient))
        };
        private Func<Assembly, string> GetAssemblyXmlFile => (assembly) => (assembly.GetName().Name + ".xml");

        public XmlDocumentationReader(string xmlPath)
        {
            reader = new DocXmlReader(xmlPath);
        }
        public XmlDocumentationReader(List<Assembly> assemblys)
        {
            assemblys = LoadReferencedAssemblys(assemblys);
            string currentPath = GetAssemblyXmlFile.Invoke(assemblys[0]);

            reader = new DocXmlReader(assemblys, GetAssemblyXmlFile);
        }
        public XmlDocumentationReader(List<Assembly> assemblys, Func<Assembly, string> assemblyXmlFileFunction)
        {
            assemblys = LoadReferencedAssemblys(assemblys);

            reader = new DocXmlReader(assemblys, assemblyXmlFileFunction, true);
        }
        public XmlDocumentationReader(XPathDocument xPathDocument)
        {
            reader = new DocXmlReader(xPathDocument, true);
        }

        private List<Assembly> LoadReferencedAssemblys(List<Assembly> assemblysForDocumentation)
        {
            if (!referencedAsseblysLoaded)
            {
                Assembly.GetCallingAssembly()
                .GetReferencedAssemblies()
                .ToList()
                .ForEach(assembly => assemblysForDocumentation.Add(Assembly.Load(assembly.FullName)));

                assemblysForDocumentation.AddRange(defaultAsseblies);
                referencedAsseblysLoaded = true;
            }

            return assemblysForDocumentation;
        }
        public TypeComment GetTypeComment(Type type) => new TypeComment(reader.GetTypeComments(type), type.Name);
        public EnumComments GetEnumComments(Type type) => reader.GetEnumComments(type, fillValues: true);
        public List<MethodComment> GetMethodCommets(Type type)
        {
            List<MethodComment> commonComments = new List<MethodComment>();

            MethodInfo[] methodInfos = type.GetMethods();

            foreach (MethodInfo methodInfo in methodInfos)
            {
                var currentComment = reader.GetMemberComment(methodInfo);
                commonComments.Add(new MethodComment(currentComment, methodInfo));
            }

            return commonComments.Where(s => s.MethodInfo.MemberType == MemberTypes.Method
                                            && !s.MethodInfo.Name.StartsWith("set_") //setter
                                            && !s.MethodInfo.Name.StartsWith("get_") // Getter
                                            && !s.MethodInfo.Name.StartsWith("add_") // AddEvent
                                            && !s.MethodInfo.Name.StartsWith("remove_") // Remove event
                                            && !s.MethodInfo.Name.StartsWith("op_") // Operator überladung
                                            && s.MethodInfo.IsPublic
                                            ).ToList();
        }
        public List<ConstructorComment> GetConstructorCommets(Type type)
        {
            List<ConstructorComment> commonComments = new List<ConstructorComment>();

            ConstructorInfo[] methodInfos = type.GetConstructors();

            foreach (ConstructorInfo constructorInfo in methodInfos)
            {
                var currentComment = reader.GetMemberComment(constructorInfo);
                commonComments.Add(new ConstructorComment(currentComment, constructorInfo));
            }

            return commonComments.Where(s => s.ConstructorInfo.MemberType == MemberTypes.Constructor).ToList();
        }
        public List<PropertyComment> GetPropertyComments(Type type)
        {
            List<PropertyComment> commonComments = new List<PropertyComment>();

            PropertyInfo[] propertyInfos = type.GetProperties();

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                var currentComment = reader.GetMemberComment(propertyInfo);
                commonComments.Add(new PropertyComment(currentComment, propertyInfo));
            }

            return commonComments.Where(s => s.PropertyInfo.MemberType == MemberTypes.Property).ToList();

        }

    }

}
