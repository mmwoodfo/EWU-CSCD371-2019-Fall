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

        //--------------- 1 : CsvRows Property ----------------//
        public IEnumerable<string> CsvRows
        {
            get
            {
                string[] lines = File.ReadAllLines(FilePath);
                lines = lines.Skip(1).ToArray();

                foreach (String line in lines)
                {
                    yield return line;
                }
            }
        }

        //--------------- 2 : Get Unique Sorted List Of States Given CSV Rows ----------------//
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            var states =
                CsvRows
                .Select(row => ParsePerson(row))
                .Select(p => p.Address.State);

            return states.OrderBy(s => s).Distinct();
        }

        //--------------- 3 : Get Aggregated Sorted List Of States Using CSV Rows ----------------//
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            IEnumerable<string> uniqueSortedListOfStates = GetUniqueSortedListOfStatesGivenCsvRows();

            string[] states = uniqueSortedListOfStates.ToArray();

            return string.Join(",", states);
        }

        //--------------- 4 : People Property ----------------//
        public IEnumerable<IPerson> People
        {
            get
            {
                var people =
                    CsvRows
                    .Select(row => ParsePerson(row))
                    .OrderBy(p => p.Address.State)
                    .ThenBy(p => p.Address.City)
                    .ThenBy(p => p.Address.Zip);

                return people;
            }
        }

        //--------------- 5 : Filter By Email Address ----------------//
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
        {
            var email =
                from person in People
                where filter(person.EmailAddress)
                select (person.FirstName, person.LastName);

            return email;
        }

        //--------------- 6 : Get Aggregated List Of States Given People Collection ----------------//
        public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people)
        {
            var states =
                people
                .Select(p => p.Address.State)
                .Distinct()
                .Aggregate((abbreviation1, abbreviation2) => $"{abbreviation1},{abbreviation2}");

            return states;
        }

        //Static Parsing functions
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
    }
}
