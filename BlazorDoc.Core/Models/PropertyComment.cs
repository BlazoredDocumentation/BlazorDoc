using System.Reflection;

namespace BlazorDoc.Models
{
    public class PropertyComment
    {
        public string Summary { get; set; }
        public PropertyInfo PropertyInfo { get; set; }
        public PropertyComment(string summary, PropertyInfo propertyInfo)
        {
            Summary = summary;
            PropertyInfo = propertyInfo;
        }
    }
}
