using System;

namespace ReEntry.WebAPI.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string TaxId { get; private set; }

        public Person(string firstName, string lastName, string taxId)
        {
            FirstName = firstName;
            LastName = lastName;
            TaxId = taxId;
        }

        public Person Copy()
        {
            return new Person(FirstName, LastName, TaxId);
        }
    }
}