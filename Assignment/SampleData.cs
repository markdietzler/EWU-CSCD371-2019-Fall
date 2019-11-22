using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Assignment
{
    public class SampleData : ISampleData
    {
        public enum Column
        {
            Id, FirstName, LastName, Email, StreetAddress, City, State, Zip
        }


        // 1.
        public IEnumerable<string> CsvRows => throw new NotImplementedException();

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() 
            => throw new NotImplementedException();

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => throw new NotImplementedException();

        // 4.
        public IEnumerable<IPerson> People => throw new NotImplementedException();

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => throw new NotImplementedException();

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();


        public IEnumerable<(string, IEnumerable<Address>)> SelectStateWithChildAddresses()
        {
            List<string> headers = null;
            IEnumerable<Address> addresses = File.ReadAllLines("People.csv")
                .Where(item =>
                {
                    if (headers is null)
                    {
                        headers = item.Split(',').ToList();
                        return false;
                    }
                    return !string.IsNullOrWhiteSpace(item);
                })
                .Select(item =>
                {

                    string[] columns = item.Split(',');
                    return new Address()
                    {
                        StreetAddress = columns[headers.IndexOf("StreetAddress")],
                        City = columns[(int)Column.City],
                        State = columns[(int)Column.State],
                        Zip = columns[(int)Column.Zip],
                    };
                }).OrderBy(item=>item.State);

            // Leveraging Query Expression
            IEnumerable<IGrouping<string, Address>> stateWithAddress =
                from item in addresses group item by item.State;

            // Using Standard Query Operators
            stateWithAddress =
                addresses.GroupBy(item => item.State);

            return stateWithAddress.Select(item =>
                (item.Key, (IEnumerable<Address>)item));
        }
    }
}
