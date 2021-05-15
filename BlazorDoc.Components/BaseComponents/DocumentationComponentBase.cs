using Microsoft.AspNetCore.Components;

namespace BlazorDoc.Components
{
    public abstract class DocumentationComponentBase : DomComponentBase, IDocumentationComponent
    {
        [Inject] public IXmlDocumentationReader XmlDocumentationReader { get; set; }

        [Parameter] public string Heading { get; set; }
        [Parameter] public RenderFragment Description { get; set; }
        [Parameter] public RenderFragment Overview { get; set; }
        [Parameter] public RenderFragment Api { get; set; }
        [Parameter] public RenderFragment Examples { get; set; }

    }
}
