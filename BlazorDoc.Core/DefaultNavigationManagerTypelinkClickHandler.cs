using Microsoft.AspNetCore.Components;
using System;

namespace BlazorDoc.Core
{
    public class DefaultNavigationManagerTypelinkClickHandler : ITypelinkClickHandler
    {
        NavigationManager _navigationManager;
        public DefaultNavigationManagerTypelinkClickHandler(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }
        public void OnTypelinkClicked(Type type)
        {
            _navigationManager.NavigateTo("/documentation/{propertyname}/details".Replace("{propertyname}", type.GetCleanedTypeName()));
        }
    }
}
