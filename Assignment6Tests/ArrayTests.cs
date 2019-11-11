using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment6.Tests
{
    [TestClass()]
    public class ArrayTests
    {
        /*------------------------------ Array Constructor Tests -------------------------------------------------*/
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

        /*------------------------------ Array Count Test -------------------------------------------------*/
        [DataTestMethod]
        //Arrange
        [DataRow(new int[] { 1, 2, 3, 4 })]
        [DataRow(new int[] { 1 })]
        [DataRow(new int[] { 1, 2, 3, 4, 20, 12, 35, 343, 11 })]
        [TestMethod()]
        public void CountTest(int[] intArray)
        {
            //Act
            ArrayCollection<int> items = new ArrayCollection<int>(intArray);

            //Assert
            Assert.AreEqual(intArray.Length, items.Count);
        }

        /*------------------------------ Array ReadOnly Test -------------------------------------------------*/
        [TestMethod()]
        public void IsReadOnlyTest()
        {
            //Arrange & Act
            ArrayCollection<string> items = new ArrayCollection<string>(5);

            //Assert
            Assert.IsFalse(items.IsReadOnly);
        }

        /*------------------------------ Array Add Item Tests -------------------------------------------------*/
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

        /*------------------------------ Array Clear Test -------------------------------------------------*/
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

        /*------------------------------ Array Contains Tests -------------------------------------------------*/
        [DataTestMethod]
        [DataRow(new string[] { "Hello", "World" })]
        [DataRow(new string[] { "This", "IS", "an", "ARrAy" })]
        [DataRow(new string[] { "1.3", "2.0", "3.0", "4.4", "20.125", "12.1132", "35.001", "343.0", "11.11119" })]
        [TestMethod()]
        public void ContainsTest_True(string[] stringArray)
        {
            //Arrange
            ArrayCollection<string> items = new ArrayCollection<string>(stringArray);

            //Act & Assert
            foreach (string str in stringArray)
            {
                Assert.IsTrue(items.Contains(str));
            }
        }

        [TestMethod()]
        public void ContainsTest_FalseNull()
        {
            //Arrange
            string[] stringArray = new string[] { "1.3", "2.0", "3.0", "4.4", "20.125", "12.1132", "35.001", "343.0", "11.11119" };
            ArrayCollection<string> items = new ArrayCollection<string>(stringArray);

            //Act & Assert
            Assert.IsFalse(items.Contains(null));
        }

        [TestMethod()]
        public void ContainsTest_False()
        {
            //Arrange
            string[] stringArray = new string[] { "1.3", "2.0", "3.0", "4.4", "20.125", "12.1132", "35.001", "343.0", "11.11119" };
            ArrayCollection<string> items = new ArrayCollection<string>(stringArray);

            //Act & Assert
            Assert.IsFalse(items.Contains("Three Point One"));
        }

        /*------------------------------ Array CopyTo Tests -------------------------------------------------*/
        [DataTestMethod]
        [DataRow(new string[] { "Hello", "World" })]
        [DataRow(new string[] { "This", "IS", "an", "ARrAy" })]
        [DataRow(new string[] { "1.3", "2.0", "3.0", "4.4", "20.125", "12.1132", "35.001", "343.0", "11.11119" })]
        [TestMethod()]
        public void CopyToTest_NoException(string[] stringArray)
        {
            //Arrange
            ArrayCollection<string> items = new ArrayCollection<string>(stringArray);
            string[] destinationArray = new string[stringArray.Length];

            //Act
            items.CopyTo(destinationArray, 0);

            //Assert
            for (int i = 0; i < items.Capacity; i++)
            {
                Assert.AreEqual(destinationArray[i], stringArray[i]);
            }
        }

        [TestMethod()]
        public void CopyToTest_ArrayIndexGreaterThanCapacity_ThrowException()
        {
            //Arrange
            string[] stringArray = new string[] { "1.3", "2.0", "3.0", "4.4", "20.125", "12.1132", "35.001", "343.0", "11.11119" };
            ArrayCollection<string> items = new ArrayCollection<string>(stringArray);
            string[] destinationArray = new string[stringArray.Length];

            //Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => items.CopyTo(destinationArray, items.Capacity + 1));
        }

        [TestMethod()]
        public void CopyToTest_ArrayIndexLessThan0_ThrowException()
        {
            //Arrange
            string[] stringArray = new string[] { "1.3", "2.0", "3.0", "4.4", "20.125", "12.1132", "35.001", "343.0", "11.11119" };
            ArrayCollection<string> items = new ArrayCollection<string>(stringArray);
            string[] destinationArray = new string[stringArray.Length];

            //Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => items.CopyTo(destinationArray, -1));
        }

        [TestMethod()]
        public void CopyToTest_ArrayIndexGreaterThanArrayLength_ThrowException()
        {
            //Arrange
            string[] stringArray = new string[] { "1.3", "2.0", "3.0", "4.4", "20.125", "12.1132", "35.001", "343.0", "11.11119" };
            ArrayCollection<string> items = new ArrayCollection<string>(stringArray);
            string[] destinationArray = new string[stringArray.Length];

            //Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => items.CopyTo(destinationArray, stringArray.Length + 1));
        }

        [TestMethod()]
        public void CopyToTest_ArrayIsNull_ThrowException()
        {
            //Arrange
            string[] stringArray = new string[] { "1.3", "2.0", "3.0", "4.4", "20.125", "12.1132", "35.001", "343.0", "11.11119" };
            ArrayCollection<string> items = new ArrayCollection<string>(stringArray);

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => items.CopyTo(null, 0));
        }

        /*------------------------------ Array Remove Test -------------------------------------------------*/
        [DataTestMethod]
        [DataRow(new string[] { "Hello", "World" })]
        [DataRow(new string[] { "This", "IS", "an", "ARrAy" })]
        [DataRow(new string[] { "1.3", "2.0", "3.0", "4.4", "20.125", "12.1132", "35.001", "343.0", "11.11119" })]
        [TestMethod()]
        public void RemoveTest_True(string[] stringArray)
        {
            //Arrange
            ArrayCollection<string> items = new ArrayCollection<string>(stringArray);

            //Act
            bool tf = items.Remove(stringArray[0]);

            //Assert
            Assert.IsTrue(tf);
            Assert.IsFalse(items.Contains(stringArray[0]));
        }

        [TestMethod()]
        public void RemoveTest_FalseNull()
        {
            //Arrange
            string[] stringArray = new string[] { "Hello", "World" };
            ArrayCollection<string> items = new ArrayCollection<string>(stringArray);

            //Act
            bool tf = items.Remove(null);

            //Assert
            Assert.IsFalse(tf);
        }

        [TestMethod()]
        public void RemoveTest_False()
        {
            //Arrange
            string[] stringArray = new string[] { "Hello", "World" };
            ArrayCollection<string> items = new ArrayCollection<string>(stringArray);

            //Act
            bool tf = items.Remove("Hello World");

            //Assert
            Assert.IsFalse(tf);
        }

        /*------------------------------ Array GetEnumerator Test -------------------------------------------------*/
        [TestMethod()]
        public void GetEnumeratorTest()
        {
            //Arrange
            string[] stringArray = new string[] { "1.3", "2.0", "3.0", "4.4", "20.125", "12.1132", "35.001", "343.0", "11.11119" };
            ArrayCollection<string> items = new ArrayCollection<string>(stringArray);

            //Act
            var enumerator = items.GetEnumerator();

            //Assert
            int i = 0;
            foreach (string item in items)
            {
                Assert.IsTrue(items.Contains(stringArray[i++]));
            }

        }

        /************************************************************************************/
        //----------------------- EXTRA CREDIT ---------------------------------------------//
        /************************************************************************************/
        [TestMethod()]
        public void ConvertTo_SystemArray()
        {
            //Arrange
            string[] stringArray = new string[] { "1.3", "2.0", "3.0", "4.4", "20.125", "12.1132", "35.001", "343.0", "11.11119" };
            ArrayCollection<string> items = new ArrayCollection<string>(stringArray);

            //Act
            Array array = (Array)items;

            int i = 0;
            foreach (var item in array)
            {
                Assert.AreEqual(stringArray[i++], item);
            }
        }

        [TestMethod()]
        public void ConvertTo_ArrayCollection()
        {
            //Arrange
            string[] stringArray = new string[] { "1.3", "2.0", "3.0", "4.4", "20.125", "12.1132", "35.001", "343.0", "11.11119" };

            //Act
            ArrayCollection<string> items = (ArrayCollection<string>)stringArray;

            int i = 0;
            foreach (var item in items)
            {
                Assert.AreEqual(stringArray[i++], item);
            }
        }
    }
}