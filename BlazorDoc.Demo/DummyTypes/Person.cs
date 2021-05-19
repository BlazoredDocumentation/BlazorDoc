namespace BlazorDoc.Demo.DummyTypes
{
    /// <summary>
    /// Person
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Testsummary
        /// </summary>
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public Address Address { get; set; }
        public char CharProp { get; set; }
        public long LongProp { get; set; }
        public short ShortProp { get; set; }
        public bool BoolProp { get; set; }
        public decimal DecimalProp { get; set; }


        public double  DoubleProp { get; set; }

        public Person()
        {

        }
        public Person(string firstName, string lastName)
        {
            Firstname = firstName;
            Name = lastName;
        }
    }
}
