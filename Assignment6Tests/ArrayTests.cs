using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment6;
using System;

namespace Assignment6.Tests
{
    [TestClass()]
    public class ArrayTests
    {
        [DataTestMethod]
        //Arrange
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(-100)]
        [TestMethod()]
        public void ArrayTest_CapacityParamBelow0_Exception(int capacity)
        {
            //Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new ArrayCollection<int>(capacity));
        }

        [DataTestMethod]
        //Arrange
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(100)]
        [TestMethod()]
        public void ArrayTest_CapacityParamAbove0_NoExcpetion(int capacity)
        {
            //Act
            ArrayCollection<int> items = new ArrayCollection<int>(capacity);

            //Act & Assert
            Assert.AreEqual(capacity, items.Capacity);
        }

        [TestMethod()]
        public void ArrayTest_CollectionParamNull_NullException()
        {
            //Arrange, Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new ArrayCollection<int>(null));
        }

        [TestMethod()]
        public void ArrayTest_CollectionParamEmpty_ArgumentOutOfRangeException()
        {
            //Arrange
            int[] intArray = Array.Empty<int>();

            //Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new ArrayCollection<int>(intArray));
        }

        [TestMethod()]
        public void ArrayTest_CollectionParamNotEmpty_NoException()
        {
            //Arrange
            int[] intArray = Array.Empty<int>();

            //Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new ArrayCollection<int>(intArray));
        }

        [DataTestMethod]
        //Arrange
        [DataRow (new int[] { 1, 2, 3, 4})]
        [DataRow(new int[] { 1 })]
        [DataRow(new int[] { 1, 2, 3, 4, 20, 12, 35, 343, 11 })]
        [TestMethod()]
        public void CountTest(int[] intArray)
        {
            //Act
            ArrayCollection<int> items = new ArrayCollection<int>(intArray);

            //Assert
#pragma warning disable CA1062 // Validate arguments of public methods
            Assert.AreEqual(intArray.Length, items.Count);
#pragma warning restore CA1062 // Validate arguments of public methods
        }

        [TestMethod()]
        public void IsReadOnlyTest()
        {
            //Arrange & Act
            ArrayCollection<string> items = new ArrayCollection<string>(5);

            //Assert
            Assert.IsTrue(items.IsReadOnly);
        }

        [TestMethod()]
        public void AddTest_ItemIsNotNull_NoException()
        {
            //Arrange


            //Act


            //Assert

        }

        [TestMethod()]
        public void AddTest_ItemIsNull_ArgumentNullException()
        {
            //Arrange


            //Act


            //Assert

        }

        [TestMethod()]
        public void ClearTest()
        {
            //Arrange


            //Act


            //Assert

        }

        [TestMethod()]
        public void ContainsTest()
        {
            //Arrange


            //Act


            //Assert

        }

        [TestMethod()]
        public void CopyToTest()
        {
            //Arrange


            //Act


            //Assert

        }

        [TestMethod()]
        public void RemoveTest()
        {
            //Arrange


            //Act


            //Assert

        }

        [TestMethod()]
        public void GetEnumeratorTest()
        {
            //Arrange


            //Act


            //Assert

        }
    }
}