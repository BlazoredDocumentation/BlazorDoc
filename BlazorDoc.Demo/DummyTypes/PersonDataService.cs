namespace BlazorDoc.Demo.DummyTypes
{
    public interface IPersonDataService
    {
        void CreatePerson();
        void DeletePerson();
        Person GetPerson();
        void UpdatePerson();
    }

    public  class PersonDataService : IPersonDataService
    {
        public Person GetPerson() => new Person();
        public virtual void CreatePerson() { }
        public void UpdatePerson() => new Person();
        public void DeletePerson() => new Person();

    }
}
