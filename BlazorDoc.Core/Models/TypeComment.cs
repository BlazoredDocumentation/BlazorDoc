using LoxSmoke.DocXml;

namespace BlazorDoc.Models
{
    public class TypeComment : CommonComments
    {
        public TypeComment(CommonComments commonComments, string sourceName)
        {
            Example = commonComments.Example;
            Inheritdoc = commonComments.Inheritdoc;
            Remarks = commonComments.Remarks;
            Summary = commonComments.Summary;

            SourceName = sourceName;

        }
        public string SourceName { get; set; }

    }

}
