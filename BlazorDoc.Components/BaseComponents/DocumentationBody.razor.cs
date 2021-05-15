using BlazorDoc.Core;
using Microsoft.AspNetCore.Components;
using System;

namespace BlazorDoc.Components
{
    public class DocumentationBodyBase : DocumentationComponentBase
    {
        [Parameter] public Type Type { get; set; }
        [Inject] public IReadmePageReader ReadmePageReader { get; set; }
        [Inject] public IColorTheme ColorTheme { get; set; }

        public string SourceName => XmlDocumentationReader.GetTypeComment(Type).SourceName;
        public MarkupString Summary => (MarkupString)XmlDocumentationReader.GetTypeComment(Type).Summary;
        public MarkupString ExampleFromXml => (MarkupString)XmlDocumentationReader.GetTypeComment(Type).Example;

        public bool HasExamples => !string.IsNullOrWhiteSpace(ExampleFromXml.Value) || Examples != null;
        public bool HasOverview => Overview != null;
    }
}
