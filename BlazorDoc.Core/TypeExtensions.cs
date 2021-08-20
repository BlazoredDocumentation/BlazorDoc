using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorDoc.Core
{
    public static class TypeExtensions
    {
        private static Dictionary<string, string> _typeNameMap => new Dictionary<string, string>(){
            {typeof(bool).Name,"bool"},{typeof(bool[]).Name,"bool[]"},
            {typeof(int).Name,"int"},{typeof(int[]).Name,"int[]"},
            {typeof(short).Name,"short"}, {typeof(short[]).Name,"short[]"},
            {typeof(long).Name,"long"},  {typeof(long[]).Name,"long[]"},
            {typeof(string).Name,"string" },{typeof(string[]).Name,"string[]" },
            {typeof(void).Name,"void" },
            {typeof(char).Name,"char" },{typeof(char[]).Name,"char[]" },
            {typeof(decimal).Name,"decimal" }, {typeof(decimal[]).Name,"decimal[]" },
            {typeof(double).Name,"double"}, {typeof(double[]).Name,"double[]"}
            };

        public static string GetHumanIntrestingTypeName(this Type type)
        {
            string typeName = type.Name;
            string mappedName;
            _typeNameMap.TryGetValue(type.Name, out mappedName);

            typeName = mappedName ?? typeName;

            return typeName;
        }
        public static string GetCleanedTypeName(this Type type)
        {
            string currentTypeName = type.FullName;
            if (type.IsArray || type.IsPointer)
            {
                currentTypeName = currentTypeName
                    .Replace("[]", string.Empty)
                    .Replace("*", string.Empty);
            }
            return currentTypeName;
        }
        /// <summary>
        /// Returns the type name. If this is a generic type, appends
        /// the list of generic type arguments between angle brackets.
        /// (Does not account for embedded / inner generic arguments.)
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>System.String.</returns>
        public static string GetFormattedName(this Type type)
        {
            if (type.IsGenericType)
            {
                string genericArguments = type.GetGenericArguments()
                                    .Select(x => x.GetFormattedName())
                                    .Aggregate((x1, x2) => $"{x1},{x2}");
                return $"{type.Name.Substring(0, type.Name.IndexOf("`"))}"
                     + $"<{genericArguments}>";
            }
            return type.GetHumanIntrestingTypeName();
        }
    }
}
