﻿namespace BlazorDoc.Demo.DummyTypes
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

    }
}
