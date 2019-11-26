using System.Linq;
using System.Collections.Generic;
using System;

namespace Assignment
{
    public class Person : IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public IAddress Address { get; set; }

        public Person(string csvRow)
        {
            if (csvRow is null)
                throw new ArgumentNullException(nameof(csvRow));
            string[] rowData = csvRow.Split(',');
            FirstName = rowData[(int)SampleData.Column.FirstName];
            LastName = rowData[(int)SampleData.Column.LastName];
            EmailAddress = rowData[(int)SampleData.Column.Email];
            Address = new Address(csvRow);
        }

        public override bool Equals(object? obj)
        {
            return obj is Person person &&
// I tried to suppress this in a suppression file numerous times, but I think my VS is broke
#pragma warning disable CA1307
                   FirstName.Equals(person.FirstName) &&
                   LastName.Equals(person.LastName) &&
                   Address.Equals(person.Address) &&
                   EmailAddress.Equals(person.EmailAddress);
#pragma warning restore CA1307
        }

        public override int GetHashCode()
        {
            return (FirstName, LastName, Address, EmailAddress).GetHashCode();
        }
    }
}
