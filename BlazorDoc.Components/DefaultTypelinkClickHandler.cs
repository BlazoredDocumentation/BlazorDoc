using Microsoft.AspNetCore.Components;
using System;

namespace BlazorDoc.Components
{
    public class DefaultTypelinkClickHandler : ITypelinkClickHandler
    {
        NavigationManager _navigationManager;
        public DefaultTypelinkClickHandler(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }
        public void OnTypelinkClicked(Type type)
        {
            _navigationManager.NavigateTo("/documentation/{propertyname}/details".Replace("{propertyname}", type.FullName));
        }
    }
}
