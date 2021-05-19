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
        [InlineData("bool[]", typeof(bool[]))]
        [InlineData("string", typeof(string))]
        [InlineData("string[]", typeof(string[]))]
        [InlineData("short", typeof(Int16))]
        [InlineData("short[]", typeof(Int16[]))]
        [InlineData("int", typeof(Int32))]
        [InlineData("long", typeof(Int64))]
        [InlineData("char", typeof(Char))]
        [InlineData("char[]", typeof(Char[]))]
        [InlineData("decimal", typeof(decimal))]
        [InlineData("double", typeof(Double))]
        [InlineData("List<int>", typeof(List<int>))]
        [InlineData("List<int[]>", typeof(List<int[]>))]
        [InlineData("Dictionary<int,string>", typeof(Dictionary<int,string>))]
        [InlineData("Func<int,string>", typeof(Func<int, string>))]
        [InlineData("Action<int,string>", typeof(Action<int,string>))]
        public void Can_Convert_TypeNames(string expectedOutputName,Type type)
        {
 
            //Act
            var actualOutputName=_sut.GetDisplayname(type);

            //Assert
            Assert.Equal(expectedOutputName, actualOutputName);

        }
    }
}
