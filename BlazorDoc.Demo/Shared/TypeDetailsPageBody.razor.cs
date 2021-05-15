using BlazorDoc.Components;
using BlazorDoc.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDoc.Demo.Shared
{
    public partial class TypeDetailsPageBody : ComponentBase
    {
        [Parameter] public string Propertyname { get; set; }
        [Parameter] public List<Assembly> Assemblies { get; set; }
        [Inject] public IAssemblyRegistrationContainer AssemblyRegistrationContainer { get; set; }
        [Inject] public IColorTheme ColorTheme { get; set; }

        Type type;
        Type GetPropertyTypeFromRegistedAssemblies()
        {
            return  AssemblyRegistrationContainer.GetPropertyTypeFromRegistedAssemblies(Propertyname);
        }
        protected async override Task OnInitializedAsync()
        {
            await Task.CompletedTask;
            type = GetPropertyTypeFromRegistedAssemblies();
        }
        protected override void OnParametersSet() => type = GetPropertyTypeFromRegistedAssemblies();
    }
}
