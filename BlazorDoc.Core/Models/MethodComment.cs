using System.Reflection;

namespace BlazorDoc.Models
{
    public class MethodComment
    {
        public string Summary { get; set; }
        public MethodInfo MethodInfo { get; set; }
        public MethodComment(string summary, MethodInfo methodInfo)
        {
            MethodInfo = methodInfo;
            Summary = summary;
        }
    }
}
