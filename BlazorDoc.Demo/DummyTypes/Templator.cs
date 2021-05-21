using System;
using System.Collections.Generic;

namespace BlazorDoc.Demo.DummyTypes
{
    /// <summary>
    /// Das ist ein DummyTemplator
    /// </summary>
    /// <typeparam name="T">T muss eine Klasse sein</typeparam>
    public class Templator<T> where T : class
    {
        public string Identification { get; set; }
        public Func<string> AFunction { get; set; }
        public List<string> MyListOfString { get; set; }
        public List<string> GetStrings() =>  null;
        public Dictionary<bool,string> GetDictionary() => null;

        public Func<string> SomeMethod(Func<string> someValue)
        {
            return null;
        }
        public virtual Func<string> SomeMethod(Func<string> someValue,string name)
        {
            return null;
        }
        public virtual Func<string> SomeMethod(Func<List<string>> someValue, string name)
        {
            return null;
        }
    }

}
