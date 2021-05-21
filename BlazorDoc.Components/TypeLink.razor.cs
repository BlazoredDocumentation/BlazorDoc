using BlazorDoc.Core;
using Microsoft.AspNetCore.Components;
using System;

namespace BlazorDoc.Components
{
    /// <summary>
    /// Invokes  <see cref="ITypelinkClickHandler.OnTypelinkClicked(Type)"/> onClick
    /// </summary>
    public class TypeLinkBase : TypeinfoCompoentBase
    {
        [Inject] public ITypelinkClickHandler TypelinkClickHandler { get; set; }
        [Inject] public IAssemblyRegistrationContainer AssemblyRegistrationContainer { get; set; }

        /// <summary>
        /// Link Content
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        public void HandleTypeLinkClick(Type type)
        {
            if (IsClickable())
            {
                TypelinkClickHandler.OnTypelinkClicked(type);
            }
                
        }
 
        public bool IsClickable()
        {
            string currentTypeName = Type.GetCleanedTypeName();

            return Type!=null && AssemblyRegistrationContainer.HasRegistedAssemblyForPropertyname(currentTypeName);
        }
    }
}
