using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorDoc.Core
{
    public static class TypeListExtensions
    {
        /// <summary>
        /// Returns all Types with a RouteAttibute
        /// </summary>
        /// <param name="components"></param>
        /// <returns></returns>
        public static List<Type> FilterByRouteAttrib(this List<Type> components)
        {
            return components.Where(c => c.GetCustomAttributes(inherit: true)
                                                  .OfType<RouteAttribute>()
                                                  .ToArray()
                                                  .Any()).ToList();
        }
    }
}
