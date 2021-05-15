using Xunit;
using BlazorDoc.Components;
using System.Collections.Generic;
using System.Reflection;

namespace BlazorDoc.Core.Tests
{
    public class XmlDocumentationReaderIntegrationTest
    {
        IXmlDocumentationReader _sut;
        public XmlDocumentationReaderIntegrationTest()
        {
            List<Assembly> assemblies = new List<Assembly>()
            {
                {Assembly.GetAssembly(typeof(string))}
            };
            _sut = new XmlDocumentationReader(assemblies);
        }

        [Fact]
        public void can_read_TypeComments()
        {
            //Arrange
            var expected = _sut.GetTypeComment(typeof(string));

            //Assert

            Assert.NotNull(expected);
        }
        [Fact]
        public void can_read_summary()
        {
            //Arrange
            var expected = _sut.GetTypeComment(typeof(DummyClass)).Summary;

            //Assert

            Assert.NotNull(expected);
        }
    }
}
