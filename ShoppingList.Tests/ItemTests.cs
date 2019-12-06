using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ShoppingList.Tests
{
    [TestClass()]
    public class ItemTests
    {
        [TestMethod()]
        public void Item_PassString_CreateItem()
        {
            //Arrange
            string expected = "Apples";

            //Act
            Item item = new Item(expected);

            //Assert
            Assert.AreEqual(expected, item.Name);
        }

        [TestMethod()]
        public void Item_PassNull_CreateItem()
        {
            //Arrange, Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Item(null!));
        }
    }
}