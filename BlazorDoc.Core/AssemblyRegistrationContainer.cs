using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BlazorDoc.Core
{
    public class AssemblyRegistrationContainer : IAssemblyRegistrationContainer
    {
        List<Assembly> assemblies;
        public AssemblyRegistrationContainer(List<Assembly> assemblies)
        {
            this.assemblies = assemblies;
        }
        public bool HasRegistedAssemblyForPropertyname(string propertyname)
        {
            //return GetPropertyTypeFromRegistedAssemblies(propertyname) != null;
            return true;
        }
        public Type GetPropertyTypeFromRegistedAssemblies(string propertyname)
        {
            if (propertyname == null)
                return null;

            var types = assemblies
                .FindLast(assembly => assemblies.Any(a=>a.DefinedTypes.Any(t=>t.FullName==propertyname)))?
                .GetTypes();

            Type currentType = types?.Where(type => type.FullName.Equals(propertyname))
                                   .FirstOrDefault();

            return currentType;
        }
    }
}
