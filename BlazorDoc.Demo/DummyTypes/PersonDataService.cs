using System;
using System.Collections.Generic;

namespace BlazorDoc.Demo.DummyTypes
{
    public interface IPersonDataService
    {   
        /// <summary>
        /// Creates a new Person in Database
        /// </summary>
        /// <param name="person">The person to create</param>
        void CreatePerson(Person person);
        void DeletePerson();
        Person GetPerson();
        void UpdatePerson();
    }

    public  class PersonDataService : IPersonDataService
    {
        public Person GetPerson() => new Person();
        public virtual void CreatePerson(Person person) { }
        public void UpdatePerson() => new Person();
        public void DeletePerson() => new Person();
        public Func<string> SomeMethod(Func<string> someValue)
        {
            return null;
        }
        public virtual Func<string> SomeMethod(Func<string> someValue, string name)
        {
            return null;
        }
        public virtual Func<string> SomeMethod(Func<List<string>> someValue, string name)
        {
            return null;
        }

    }
}
