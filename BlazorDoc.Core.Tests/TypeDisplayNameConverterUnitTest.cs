using System;
using Xunit;
using BlazorDoc.Components;
using System.Collections.Generic;

namespace BlazorDoc.Core.Tests
{
    public class TypeDisplayNameConverterUnitTest
    {
        readonly ITypeDisplayNameConverter _sut;

        public TypeDisplayNameConverterUnitTest()
        {
            _sut = new TypeDisplayNameConverter();
        }


        [Theory]
        [InlineData("bool",typeof(bool))]
        [InlineData("string", typeof(string))]
        [InlineData("short", typeof(Int16))]
        [InlineData("short", typeof(short))]
        [InlineData("int", typeof(Int32))]
        [InlineData("int", typeof(int))]
        [InlineData("long", typeof(Int64))]
        [InlineData("char", typeof(Char))]
        [InlineData("char", typeof(char))]
        [InlineData("decimal", typeof(decimal))]
        [InlineData("decimal", typeof(Decimal))]
        [InlineData("double", typeof(Double))]
        [InlineData("List<int>", typeof(List<int>))]
        [InlineData("Dictionary<int,string>", typeof(Dictionary<int,string>))]
        [InlineData("Dictionary<int,string>", typeof(Dictionary<int, string>))]
        [InlineData("Func<int,string>", typeof(Func<int, string>))]
        public void Can_Convert_TypeNames(string expectedOutputName,Type type)
        {
 
            //Act
            var actualOutputName=_sut.GetDisplayname(type);

            //Assert
            Assert.Equal(expectedOutputName, actualOutputName);

        }
    }
}
