using System;

namespace BlazorDoc.Components
{
    public interface ITypeDisplayNameConverter
    {
        string GetDisplayname(Type type);
    }
}
