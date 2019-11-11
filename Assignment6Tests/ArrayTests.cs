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
            Assert.IsFalse(items.IsReadOnly);
        }

        [TestMethod()]
        public void AddTest_ItemIsNotNull_NoException()
        {
            //Arrange
            ArrayCollection<int> items = new ArrayCollection<int>(10);

            //Act
            int item = 3;
            items.Add(item);

            //Assert
            Assert.IsTrue(items.Contains(item));
        }

        [TestMethod()]
        public void AddTest_ItemIsNull_ArgumentNullException()
        {
            //Arrange
            ArrayCollection<string> items = new ArrayCollection<string>(10);

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => items.Add(null));
        }

        [DataTestMethod]
        [DataRow(new double[] { 1.0, 2.1, 3.14, 4.215 })]
        [DataRow(new double[] { 1.5 })]
        [DataRow(new double[] { 1.3, 2.0, 3.0, 4.4, 20.125, 12.1132, 35.001, 343.0, 11.11119 })]
        [TestMethod()]
        public void ClearTest(double[] doubleArray)
        {
            //Arrange
            ArrayCollection<double> items = new ArrayCollection<double>(doubleArray);

            //Act
            items.Clear();

            //Assert
            Assert.AreEqual(0, items.Count);
        }

        [DataTestMethod]
        [DataRow(new string[] { "Hello", "World" })]
        [DataRow(new string[] { "This", "IS", "an", "ARrAy" })]
        [DataRow(new string[] { "1.3", "2.0", "3.0", "4.4", "20.125", "12.1132", "35.001", "343.0", "11.11119" })]
        [TestMethod()]
        public void ContainsTest(string[] stringArray)
        {
            //Arrange
            ArrayCollection<string> items = new ArrayCollection<string>(stringArray);

            //Act & Assert
#pragma warning disable CA1062 // Validate arguments of public methods
            foreach (string str in stringArray)
#pragma warning restore CA1062 // Validate arguments of public methods
            {
                Assert.IsTrue(items.Contains(str));
            }
        }

        [TestMethod()]
        public void CopyToTest()
        {
            //Arrange


            //Act


            //Assert

        }


        [DataTestMethod]
        [DataRow(new string[] { "Hello", "World" })]
        [DataRow(new string[] { "This", "IS", "an", "ARrAy" })]
        [DataRow(new string[] { "1.3", "2.0", "3.0", "4.4", "20.125", "12.1132", "35.001", "343.0", "11.11119" })]
        [TestMethod()]
        public void RemoveTest(string[] stringArray)
        {
            //Arrange
            ArrayCollection<string> items = new ArrayCollection<string>(stringArray);

            //Act
#pragma warning disable CA1062 // Validate arguments of public methods
            bool tf = items.Remove(stringArray[0]);
#pragma warning restore CA1062 // Validate arguments of public methods

            //Assert
            Assert.IsTrue(tf);
            Assert.IsFalse(items.Contains(stringArray[0]));
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