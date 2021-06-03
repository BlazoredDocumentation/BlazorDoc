namespace BlazorDoc.Demo.DummyTypes
{
    /// <summary>
    /// TestSummary of Person. This is a DummyPerson 
    /// </summary>
    public class Person
    {
        /// <summary>
        /// The uniqe id of this Person
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// This Firstname 
        /// </summary>
        public string Firstname { get; set; }
        /// <summary>
        /// The Lastname
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The Gender
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// The Address
        /// </summary>
        public Address Address { get; set; }
        /// <summary>
        /// A Summary of for CharProp
        /// </summary>
        public char CharProp { get; set; }
        public long LongProp { get; set; }
        /// <summary>
        /// This is a Shortprop with a very long lorem ipsum comment. 
        /// We need this comment is to check if long comments are readable in this documentation
        /// Feel free to make suggestions to improve the UX
        /// </summary>
        public short ShortProp { get; set; }
        public bool BoolProp { get; set; }
        public decimal DecimalProp { get; set; }


        public double  DoubleProp { get; set; }

 
        /// <summary>
        /// Creates a Person with 
        /// </summary>
        public Person()
        {

        }

        /// <summary>
        /// Creates a Person with the specified firstname and lastname
        /// </summary>
        /// <param name="firstName"> The Firstname of the Created Person</param>
        /// <param name="lastName">The Lastname of the Created Person</param>
        public Person(string firstName, string lastName)
        {
            Firstname = firstName;
            Name = lastName;
        }
    }
}
