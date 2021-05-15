using System;

namespace BlazorDoc.Core
{
    public interface IAssemblyRegistrationContainer
    {
        Type GetPropertyTypeFromRegistedAssemblies(string propertyname);
        bool HasRegistedAssemblyForPropertyname(string propertyname);
    }
}
