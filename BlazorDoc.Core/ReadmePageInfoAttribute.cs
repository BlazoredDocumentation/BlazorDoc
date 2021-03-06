using System;
using System.Collections.Generic;

namespace BlazorDoc.Core
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ReadmePageInfoAttribute : Attribute
    {
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public string ShortDescription { get; set; }
    }
}
