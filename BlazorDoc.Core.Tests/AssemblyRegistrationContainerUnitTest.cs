using Xunit;
using System.Collections.Generic;
using System.Reflection;
using BlazorDoc.Models;
using System;
using System.Net.Http;
using BlazorDoc.Components;

namespace BlazorDoc.Core.Tests
{
    public class AssemblyRegistrationContainerUnitTest
    {

        public static List<Assembly> DummyAssembliesToDoc = new List<Assembly>()
            {
                Assembly.GetAssembly(typeof(BlazorDoc.Components.XmlDocumentationReader)),
                Assembly.GetAssembly(typeof(BlazorDoc.Models.ConstructorComment))
            };
        AssemblyRegistrationContainer sut;

        [Fact]
        public void Can_Get_HasRegistedAssemblyForPropertyname()
        {
            //Arrange
            sut = new AssemblyRegistrationContainer(DummyAssembliesToDoc);

            //Act
            bool actual = sut.HasRegistedAssemblyForPropertyname(typeof(ConstructorComment).FullName);

            //Assert
            Assert.True(actual);

        }
        [Fact]
        public void Can_GetPropertyTypeFromRegistedAssemblies()
        {
            //Arrange
            sut = new AssemblyRegistrationContainer(DummyAssembliesToDoc);

            //Act
            Type actual = sut.GetPropertyTypeFromRegistedAssemblies(typeof(IXmlDocumentationReader).FullName);

            //Assert
            Assert.Equal(typeof(IXmlDocumentationReader).FullName, actual.FullName);

        }
        [Fact]
        public void Can_handle_null_values_GetPropertyTypeFromRegistedAssemblies()
        {
            //Arrange
            sut = new AssemblyRegistrationContainer(DummyAssembliesToDoc);

            //Act
            Type actual = sut.GetPropertyTypeFromRegistedAssemblies(null);

            //Assert
            Assert.True(true);

        }
        [Fact]
        public void Does_not_throw_if_try_to_GetPropertyTypeFromRegistedAssemblies_that_not_exists()
        {
            //Arrange
            sut = new AssemblyRegistrationContainer(new List<Assembly>());

            //Act
            _ = sut.GetPropertyTypeFromRegistedAssemblies(typeof(HttpClient).FullName);

            //Assert
            Assert.True(true);

        }
        [Fact]
        public void Does_not_throw_exceptions_if_type_not_there()
        {
            //Arrange
            sut = new AssemblyRegistrationContainer(DummyAssembliesToDoc);

            //Act
            _ = sut.HasRegistedAssemblyForPropertyname("INVALID_PROPERTYNAME");

            //Assert
            Assert.True(true);

        }
    }
}
