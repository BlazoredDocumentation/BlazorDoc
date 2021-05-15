using System.Reflection;

namespace BlazorDoc.Models
{
    public class ConstructorComment
    {
        public string Summary { get; set; }
        public ConstructorInfo ConstructorInfo { get; set; }
        public ConstructorComment(string summary, ConstructorInfo constructorInfo)
        {
            ConstructorInfo = constructorInfo;
            Summary = summary;
        }
    }
}
