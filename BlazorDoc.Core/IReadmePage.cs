using System;

namespace BlazorDoc.Core
{
    public interface IReadmePage
    {
        string Displayname { get; set; }
        string FullName { get; set; }
        string Href { get; set; }
        string Shortdescription { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
        bool ContainsObsoleteComponentes { get; }
        string ObsoleteWarningMessage { get; }
   
    }
    public static class ReadmePageExtensions
    {
        public static bool IsNew(this IReadmePage readmePage) => readmePage.CreatedAt.AddDays(30) >= DateTime.Now;
        public static bool IsUpdated(this IReadmePage readmePage) => readmePage.UpdatedAt.AddDays(30) >= DateTime.Now;
    }

}
