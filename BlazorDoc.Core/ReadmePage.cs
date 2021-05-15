using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace BlazorDoc.Core
{
    public class ReadmePage : IReadmePage
    {
        public string Displayname { get; set; }
        public string FullName { get; set; }
        public string Href { get; set; }
        public string Shortdescription { get; set; }
        public DateTime CreatedAt { get; set; } = new DateTime();
        public DateTime UpdatedAt { get; set; } = new DateTime();
        public bool ContainsObsoleteComponentes { get; set; } = false;
        public string ObsoleteWarningMessage { get; private set; }
        public ReadmePage(Type typeOfExamplePage)
        {
            Initialize(typeOfExamplePage);
        }

        private void Initialize(Type typeOfExamplePage)
        {
            TryReadExampleInfoAttribute(typeOfExamplePage);
            TryReadObsoleteAttribute(typeOfExamplePage);
            Displayname = typeOfExamplePage.Name.Replace("ReadMe", "").Replace("Readme", "");
            FullName = typeOfExamplePage.FullName;
            Href = $"/{AddDashAfterEachUpperCase(Displayname)}";
        }

        private void TryReadObsoleteAttribute(Type typeOfExamplePage)
        {
            var obsoleteAttribute = typeOfExamplePage.GetCustomAttribute<ObsoleteAttribute>();
            if (obsoleteAttribute != null)
            {
                ContainsObsoleteComponentes = true;
                ObsoleteWarningMessage = obsoleteAttribute.Message;
            }
        }

        private void TryReadExampleInfoAttribute(Type typeOfExamplePage)
        {
            var exampleInfo = typeOfExamplePage.GetCustomAttribute<ReadmePageInfoAttribute>();
            if (exampleInfo != null)
            {
                DateTime createtAt = new DateTime();
                DateTime updatetAt = new DateTime();
                if (DateTime.TryParse(exampleInfo.CreatedAt, out createtAt))
                    CreatedAt = createtAt;

                if (DateTime.TryParse(exampleInfo.UpdatedAt, out updatetAt))
                    UpdatedAt = updatetAt;

                Shortdescription = exampleInfo.ShortDescription;
            }
        }

        private string AddDashAfterEachUpperCase(string input)
        {
            return Regex.Replace(input, "([A-Z0-9])", "-$1", RegexOptions.Compiled)
                        .Trim('-')
                        .ToLower();
        }

    }

 
}
