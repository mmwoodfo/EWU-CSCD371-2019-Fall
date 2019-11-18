using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Sorter.Tests
{
    [TestClass]
    public class SortUtilityTests
    {
        [TestMethod]
        public void QuickSort_NullArray_ThrowNullException()
        {
            //Arrange
            SortUtility sorter = new SortUtility();

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => sorter.QuickSort(null!, ((int num1, int num2) => num1 < num2)));
        }

        [DataTestMethod]
        [DataRow(new int[] { 3, 2, 1 }, new int[] { 1, 2, 3 })]
        [DataRow(new int[] { 2, 1, 3, 10, 4, 32, 302, 3, 15 }, new int[] { 1, 2, 3, 3, 4, 10, 15, 32, 302 })]
        [DataRow(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestMethod]
        public void QuickSort_UsingAnonymousMethod_SortsAscending(int[] intArray, int[] expectedIntArray)
        {
            //Arrange
            SortUtility sorter = new SortUtility();
            Compare compareNumbers = delegate (int num1, int num2)
            {
                return num1 < num2;
            };

            //Act
            sorter.QuickSort(intArray, compareNumbers);

            //Assert
            CollectionAssert.AreEqual(expectedIntArray, intArray);
        }

        [DataTestMethod]
        [DataRow(new int[] { 3, 2, 1 }, new int[] { 1, 2, 3 })]
        [DataRow(new int[] { 2, 1, 3, 10, 4, 32, 302, 3, 15 }, new int[] { 1, 2, 3, 3, 4, 10, 15, 32, 302 })]
        [DataRow(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestMethod]
        public void QuickSort_UsingLambdaExpression_SortsAscending(int[] intArray, int[] expectedIntArray)
        {
            //Arrange
            SortUtility sorter = new SortUtility();

            //Act
            sorter.QuickSort(intArray, ((int num1, int num2) => num1 < num2));

            //Assert
            CollectionAssert.AreEqual(expectedIntArray, intArray);
        }

        [DataTestMethod]
        [DataRow(new int[] { 3, 2, 1 }, new int[] { 1, 2, 3 })]
        [DataRow(new int[] { 2, 1, 3, 10, 4, 32, 302, 3, 15 }, new int[] { 1, 2, 3, 3, 4, 10, 15, 32, 302 })]
        [DataRow(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestMethod]
        public void QuickSort_UsingLambdaStatement_SortsAscending(int[] intArray, int[] expectedIntArray)
        {
            //Arrange
            SortUtility sorter = new SortUtility();

            //Act
            sorter.QuickSort(intArray, ((int num1, int num2) => { return num1 < num2; }));

            //Assert
            CollectionAssert.AreEqual(expectedIntArray, intArray);
        }

        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 })]
        [DataRow(new int[] { 2, 1, 3, 10, 4, 32, 302, 3, 15 }, new int[] { 302, 32, 15, 10, 4, 3, 3, 2, 1 })]
        [DataRow(new int[] { 3, 2, 1 }, new int[] { 3, 2, 1 })]
        [TestMethod]
        public void QuickSort_UsingAnonymousMethod_SortsDescending(int[] intArray, int[] expectedIntArray)
        {
            //Arrange
            SortUtility sorter = new SortUtility();
            Compare compareNumbers = delegate (int num1, int num2)
            {
                return num1 > num2;
            };

            //Act
            sorter.QuickSort(intArray, compareNumbers);

            //Assert
            CollectionAssert.AreEqual(expectedIntArray, intArray);
        }

        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 })]
        [DataRow(new int[] { 2, 1, 3, 10, 4, 32, 302, 3, 15 }, new int[] { 302, 32, 15, 10, 4, 3, 3, 2, 1 })]
        [DataRow(new int[] { 3, 2, 1 }, new int[] { 3, 2, 1 })]
        [TestMethod]
        public void QuickSort_UsingLambdaExpression_SortsDescending(int[] intArray, int[] expectedIntArray)
        {
            //Arrange
            SortUtility sorter = new SortUtility();

            //Act
            sorter.QuickSort(intArray, ((int num1, int num2) => num1 > num2));

            //Assert
            CollectionAssert.AreEqual(expectedIntArray, intArray);
        }

        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 })]
        [DataRow(new int[] { 2, 1, 3, 10, 4, 32, 302, 3, 15 }, new int[] { 302, 32, 15, 10, 4, 3, 3, 2, 1 })]
        [DataRow(new int[] { 3, 2, 1 }, new int[] { 3, 2, 1 })]
        [TestMethod]
        public void QuickSort_UsingLambdaStatement_SortsDesending(int[] intArray, int[] expectedIntArray)
        {
            //Arrange
            SortUtility sorter = new SortUtility();

            //Act
            sorter.QuickSort(intArray, ((int num1, int num2) => { return num1 > num2; }));

            //Assert
            CollectionAssert.AreEqual(expectedIntArray, intArray);
        }
    }
}
