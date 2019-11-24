using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        public string FilePath { get; set; }

        public SampleData(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException(nameof(filePath));
            if (!File.Exists(filePath))
                throw new FileNotFoundException();

            FilePath = filePath;
        }

        /*
         Implement the ISampleData.CsvRows property, 
        */
        public IEnumerable<string> CsvRows
        {
            get
            {
                string[] lines = File.ReadAllLines(FilePath); //loading the data from the People.csv file
                lines = lines.Skip(1).ToArray(); //Using LINQ, skip the first row in the People.csv.

                foreach (String line in lines)
                {
                    yield return line; //and returning each line as a single string.
                }
            }
        }

        /*
         Implement the ISampleData.People property to return all the items in People.csv as Person objects
        */
        public IEnumerable<IPerson> People
        {
            get
            {
                var people =
                    CsvRows //Use ISampleData.CsvRows as the source of the data.
                    .Select(row => ParsePerson(row)) //Be sure that Person.Address is also populated.
                    .OrderBy(p => p.Address.State)
                    .ThenBy(p => p.Address.City)
                    .ThenBy(p => p.Address.Zip);

                return people;
            }

        }

        public static Person ParsePerson(string row)
        {
            if (row is null)
                throw new ArgumentNullException(nameof(row));

            string[] values = row.Split(',');
            string[] address = values.Skip(4).Take(4).ToArray();

            return new Person(values[1], values[2], values[3], ParseAddress(address));
        }

        public static Address ParseAddress(string[] address)
        {
            var _ = address ?? throw new ArgumentNullException(nameof(address));

            if (address.Length < 4)
                throw new ArgumentException("", nameof(address));

            return new Address(address[0], address[1], address[2], address[3]);
        }

        /*
         Implement ISampleDate.FilterByEmailAddress(Predicate<string> filter) to return a list of names where the email address matches the filter.
        */
        //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/filtering-data
        //https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.where?view=netframework-4.8
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
        {
            var email =
                from person in People //Use ISampleData.People for your data source.
                where filter(person.EmailAddress)
                select (person.FirstName, person.LastName);

            return email;
        }

        /*
         Implement ISampleData.GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people) to return a string that contains 
         a unique, comma separated list of states.
        */
        public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people)
        {
            var states =
                people //Use the people parameter from ISampleData.GetUniqueListOfStates for your data source.
                .Select(p => p.Address.State)
                .Distinct() //Don't forget the list should be unique.
                .Aggregate((abbreviation1, abbreviation2) => $"{abbreviation1}, {abbreviation2}");

            return states;
        }

        //https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.aggregate?view=netframework-4.8
        //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/sorting-data
        /*
         Implement ISampleData.GetAggregateSortedListOfStatesUsingCsvRows() to return a string that contains a unique, comma separated list of states.
        */
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            IEnumerable<string> uniqueSortedListOfStates = GetUniqueSortedListOfStatesGivenCsvRows(); //Use ISampleData.GetUniqueSortedListOfStatesGivenCsvRows for your data source.

            string[] states = uniqueSortedListOfStates.ToArray(); //Consider "selecting" only the states and calling ToArray() to retrieve an array of all the state names.

            return string.Join(",", states); //Given the array, consider using string.Join to combine the list into a single string.
        }

        //https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.distinct?view=netframework-4.8
        /*
         Implement IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() to return a sorted, unique list of states.
        */
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            var states =
                CsvRows //Use ISampleData.CsvRows for your data source.
                .Select(row => ParsePerson(row))
                .Select(p => p.Address.State);

            return states.OrderBy(s => s).Distinct(); //Don't forget the list should be unique. Sort the list alphabetically
        }
    }
}
