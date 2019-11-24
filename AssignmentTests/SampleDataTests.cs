using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment.Tests
{
    [TestClass()]
    public class SampleDataTests
    {
        private string _FilePath = "TestData.csv";

        //----------------- SAMPLE DATA TEST ----------------//
        [TestMethod()]
        public void SampleData_NullFilePath_ThrowsArgumentNullException()
        {
            //Arrange Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new SampleData(null!));
        }

        [TestMethod()]
        public void SampleData_FakeFilePath_ThrowsFileNotFoundException()
        {
            //Arrange Act & Assert
            Assert.ThrowsException<FileNotFoundException>(() => new SampleData("TheCakeIsALie.csv"));
        }

        [TestMethod()]
        public void SampleData_StringFilePath_NoException()
        {
            //Arrange 
            string filePath = _FilePath;

            //Act 
            SampleData sampleData = new SampleData(filePath);

            //Assert
            Assert.AreEqual(filePath, sampleData.FilePath);
        }

        //--------------- CSV ROWS PROPERTY TEST ----------------//
        [TestMethod()]
        public void CsvRows_ReadFile_SkipsFirstLine()
        {
            //Arrange 
            string[] fileLines = File.ReadAllLines(_FilePath);
            SampleData sampleData = new SampleData(_FilePath);

            //Act 
            var row = sampleData.CsvRows;

            //Assert
            Assert.IsFalse(row.Contains(fileLines[0]));
        }

        [TestMethod()]
        public void CsvRows_ReadFile_ReadsEachLine()
        {
            //Arrange 
            string[] fileLines = File.ReadAllLines(_FilePath);
            SampleData sampleData = new SampleData(_FilePath);

            //Act & Assert
            for (int i = 1; i < fileLines.Length; i++)
            {
                var row = sampleData.CsvRows;
                Assert.IsTrue(row.Contains(fileLines[i]));
            }
        }

        //------------------ EMAIL ADDRESSES TESTS -------------------------//
        [TestMethod()]
        public void FilterByEmailAddress_AsuEmailFilter_Return4Names()
        {
            //Arrange
            string[] fileLines = File.ReadAllLines(_FilePath);
            SampleData sampleData = new SampleData(_FilePath);
            ValueTuple<string, string>[] expectedNames = new ValueTuple<string, string>[]{
                ("Meghan", "Woodford"),
                ("Delaney", "Kranz"),
                ("Brandon", "Bayles"),
                ("Pratik", "Panda")
            };

            //Act
            IEnumerable<(string FirstName, string LastName)> filteredNames = sampleData.FilterByEmailAddress(email => email.EndsWith("asu.edu", StringComparison.Ordinal));

            //Assert
            foreach (var expectedTuple in expectedNames)
            {
                Assert.IsTrue(filteredNames.Contains(expectedTuple));
            }
        }

        //----------------------- STATES TESTS ------------------------//
        [TestMethod()]
        public void GetAggregateListOfStatesGivenPeopleCollection_AllPeople_ReturnAllStatesAggregated()
        {
            //Arrange
            string expectedStates = "AZ, AZ, ID, AZ, AZ, AZ, ID, ID, CA, WA, NC, NY, NY, MT, FL, CA, GA, TX, GA, FL";
            SampleData sampleData = new SampleData(_FilePath);

            //Act
            string states = sampleData.GetAggregateListOfStatesGivenPeopleCollection(sampleData.People);

            //Assert
            Assert.AreEqual(expectedStates, states);
        }

        [TestMethod()]
        public void GetAggregateSortedListOfStatesUsingCsvRows_ValidCsvFile_ReturnAllAggregatedStatesSorted()
        {
            //Arrange
            string expectedStates = "AZ, AZ, AZ, AZ, AZ, CA, CA, FL, FL, GA, GA, ID, ID, ID, MT, NC, NY, NY, TX, WA";
            SampleData sampleData = new SampleData(_FilePath);

            //Act
            string states = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();

            //Assert
            Assert.AreEqual(expectedStates, states);
        }

        [TestMethod()]
        public void GetUniqueSortedListOfStatesGivenCsvRows_ValidCsvFile_ReturnSortedUniqueList()
        {
            //Arrange
            string[] fileLines = File.ReadAllLines(_FilePath);
            string[] expectedStates = { "AZ", "CA", "FL", "GA", "ID", "MT", "NC", "NY", "TX", "WA" };
            SampleData sampleData = new SampleData(_FilePath);

            //Act
            IEnumerable<string> states = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

            //Assert
            Assert.IsTrue(states.SequenceEqual(expectedStates));
        }

        [TestMethod()]
        public void ParsePerson_CsvLine_ParseSuccuss()
        {
            //Arrange
            string personLine = "1,Meghan,Woodford,mmwoodfo@asu.edu,1234 noneofyourbuisness lane,Tempe,AZ,35326";
            Address address = new Address("1234 noneofyourbuisness lane", "Tempe", "AZ", "35326");
            Person expectedPerson = new Person("Meghan", "Woodford", "mmwoodfo@asu.edu", address);

            //Act
            Person person = SampleData.ParsePerson(personLine);

            //Assert
            try
            {
                Assert.AreEqual(expectedPerson.FirstName, person.FirstName);
                Assert.AreEqual(expectedPerson.LastName, person.LastName);
                Assert.AreEqual(expectedPerson.EmailAddress, person.EmailAddress);
                Assert.AreEqual(expectedPerson.Address.StreetAddress, person.Address.StreetAddress);
                Assert.AreEqual(expectedPerson.Address.City, person.Address.City);
                Assert.AreEqual(expectedPerson.Address.State, person.Address.State);
                Assert.AreEqual(expectedPerson.Address.Zip, person.Address.Zip);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [TestMethod()]
        public void ParseAddress_AddressArray_ParseSuccuss()
        {
            //Arrange
            string[] addressArray = { "1234 noneofyourbuisness lane", "Tempe", "AZ", "35326" };
            Address expectedAddress = new Address("1234 noneofyourbuisness lane", "Tempe", "AZ", "35326");

            //Act
            Address address = SampleData.ParseAddress(addressArray);

            //Assert
            try
            {
                Assert.AreEqual(expectedAddress.StreetAddress, address.StreetAddress);
                Assert.AreEqual(expectedAddress.City, address.City);
                Assert.AreEqual(expectedAddress.State, address.State);
                Assert.AreEqual(expectedAddress.Zip, address.Zip);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}