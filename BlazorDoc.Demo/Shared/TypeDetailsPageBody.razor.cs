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
    public partial class TypeDetailsPageBody : DocumentationBodyBase
    {
        [Parameter] public string Propertyname { get; set; }
        [Parameter] public List<Assembly> Assemblies { get; set; }
        [Inject] public IAssemblyRegistrationContainer AssemblyRegistrationContainer { get; set; }
        public bool IsBusy { get; set; }

        protected async override Task OnInitializedAsync() => await InitializeTypesAsync();
        protected async override Task OnParametersSetAsync() =>await InitializeTypesAsync();

        private async Task InitializeTypesAsync()
        {
        
            IsBusy = true;
            await new TaskFactory().StartNew(()=> Type = GetPropertyTypeFromRegistedAssemblies());
            await Task.Run(() => Type = GetPropertyTypeFromRegistedAssemblies());

            IsBusy = false;
        }
        Type GetPropertyTypeFromRegistedAssemblies()
        {
            return AssemblyRegistrationContainer.GetPropertyTypeFromRegistedAssemblies(Propertyname);
        }

    }
}
