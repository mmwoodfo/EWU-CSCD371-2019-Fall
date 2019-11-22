using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace Assignment.Tests
{
    [TestClass()]
    public class SampleDataTests
    {
        string _FilePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + @"\Assignment" + @"\" + "People.csv";


        [TestMethod()]
        public void SampleData()
        {
            //Arrange


            //Act


            //Assert
            Assert.Fail();
        }

        [TestMethod()]
        public void CsvRows()
        {
            /*I'll be changing this - just trying to figure out the best method of testing with csv files*/
            //Arrange
            SampleData sampleData = new SampleData(_FilePath);

            //Act
            IEnumerable<string> lines = sampleData.CsvRows;

            //Assert
            Assert.IsTrue(lines.Contains("1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577"));
        }

        [TestMethod()]
        public void FilterByEmailAddress()
        {
            //Arrange


            //Act


            //Assert
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAggregateListOfStatesGivenPeopleCollection()
        {
            //Arrange


            //Act


            //Assert
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAggregateSortedListOfStatesUsingCsvRows()
        {
            //Arrange


            //Act


            //Assert
            Assert.Fail();
        }

        [TestMethod()]
        public void GetUniqueSortedListOfStatesGivenCsvRows()
        {
            //Arrange


            //Act


            //Assert
            Assert.Fail();
        }
    }
}