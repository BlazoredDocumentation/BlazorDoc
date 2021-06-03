using Microsoft.AspNetCore.Components;

namespace BlazorDoc.Components
{
    public abstract class XmlDocumentaionComponentBase : TypeinfoCompoentBase
    {
        [Parameter] public CommentDisplayType CommentDisplayType { get; set; } = CommentDisplayType.Ever;
        [Inject] public IXmlDocumentationReader XmlDocumentationReader { get; set; }
    }
}
