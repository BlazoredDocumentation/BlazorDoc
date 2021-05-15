using BlazorDoc.Core;
using Microsoft.AspNetCore.Components;
using System;

namespace BlazorDoc.Components
{
    public class TypeLinkBase : TypeinfoCompoentBase
    {
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IAssemblyRegistrationContainer AssemblyRegistrationContainer { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }

        public void NavigateToPropertyDetailsPage(Type type)
        {
            if(IsClickable())
               NavigationManager.NavigateTo("/documentation/{propertyname}/details".Replace("{propertyname}", type.FullName));
        }
        public bool IsClickable()
        {
           return Type!=null && AssemblyRegistrationContainer.HasRegistedAssemblyForPropertyname(Type.FullName);
        }


    }
}
