using LoxSmoke.DocXml;
using System;
using System.Collections.Generic;
using BlazorDoc.Models;

namespace BlazorDoc.Components
{
    public interface IXmlDocumentationReader
    {
        List<PropertyComment> GetPropertyComments(Type type);
        List<MethodComment> GetMethodCommets(Type type);
        List<ConstructorComment> GetConstructorCommets(Type type);
        TypeComment GetTypeComment(Type type);
        EnumComments GetEnumComments(Type type);
    }

}
