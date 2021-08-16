using BlazorDoc.Core;
using System;
using System.Linq;

namespace BlazorDoc.Components
{
    public class TypeDisplayNameConverter : ITypeDisplayNameConverter
    {
        public string GetDisplayname(Type type)
        {
     
            return type.GetFormattedName();
        }
    }
}
