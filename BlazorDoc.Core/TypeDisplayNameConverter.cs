using BlazorDoc.Core;
using System;
using System.Linq;

namespace BlazorDoc.Components
{
    public class TypeDisplayNameConverter : ITypeDisplayNameConverter
    {
        public string GetDisplayname(Type type)
        {
            if (type.IsGenericType)
            {
                Type[] genericTypeArguments = type.GetGenericArguments();
                int numberOfGenericArguments = genericTypeArguments.Length;
                string genericParameters = string.Join(',', genericTypeArguments.Select(g => g.GetHumanIntrestingTypeName()));
                return type.Name.Replace($"`{numberOfGenericArguments}", "<" + genericParameters + ">");
            }
            return type.GetHumanIntrestingTypeName();
        }
    }
}
