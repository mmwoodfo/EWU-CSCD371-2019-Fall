using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        private string _FilePath;

        public SampleData(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException(nameof(filePath));
            _FilePath = filePath;
        }

        public IEnumerable<string> CsvRows 
        {
            get 
            {
                string[] lines = File.ReadAllLines(_FilePath);
                lines = lines.Skip(1).ToArray();

                foreach (String line in lines)
                {
                    yield return line;
                }
            }
        }

        public IEnumerable<IPerson> People 
        { 
            get
            {
                throw new NotImplementedException();
            }
                
        }

        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
        {
            throw new NotImplementedException();
        }

        public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people)
        {
            throw new NotImplementedException();
        }

        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            throw new NotImplementedException();
        }
    }
}
