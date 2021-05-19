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
            return GetPropertyTypeFromRegistedAssemblies(propertyname) != null; 
        }
        public Type GetPropertyTypeFromRegistedAssemblies(string propertyname)
        {
            if (propertyname == null)
                return null;
 
            var currentAssembly =
                  assemblies.Find(assembly => assembly.GetTypes().Any(t => t.FullName == propertyname));
     
            if (currentAssembly == null)
                return null;

            return currentAssembly.GetType(propertyname);
        }
    }
}
