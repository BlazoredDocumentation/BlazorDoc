using Microsoft.AspNetCore.Components;

namespace BlazorDoc.Components
{
    public abstract class XmlDocumentaionComponentBase : TypeinfoCompoentBase
    {
        [Inject] public IXmlDocumentationReader XmlDocumentationReader { get; set; }
    }
}
