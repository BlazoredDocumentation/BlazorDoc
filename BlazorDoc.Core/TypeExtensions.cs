using System;
using System.Collections.Generic;

namespace BlazorDoc.Components
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
    }
}
