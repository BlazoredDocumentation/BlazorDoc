using Microsoft.AspNetCore.Components;

namespace BlazorDoc.Components
{
    public interface IDocumentationComponent
    {
        string Heading { get; set; }
        RenderFragment Api { get; set; }
        RenderFragment Description { get; set; }
        RenderFragment Examples { get; set; }
        IXmlDocumentationReader XmlDocumentationReader { get; set; }
    }
}
