using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;

namespace ShoppingList.Tests
{
    [TestClass()]
    public class ItemStrikeThroughConverterTests
    {
        [TestMethod()]
        public void Convert_GivenTrue_ReturnStrikeThrough()
        {
            //Arrange
            ItemStrikeThroughConverter visibilityConverter = new ItemStrikeThroughConverter();
            Item item = new Item("Apples")
            {
                CheckedOff = true
            };

            var visibility = visibilityConverter.Convert(item.CheckedOff);

            Assert.AreEqual(TextDecorations.Strikethrough, visibility);
        }

        [TestMethod()]
        public void Convert_GivenFalse_ReturnNull()
        {
            //Arrange
            ItemStrikeThroughConverter visibilityConverter = new ItemStrikeThroughConverter();
            Item item = new Item("Apples")
            {
                CheckedOff = false
            };

            var visibility = visibilityConverter.Convert(item.CheckedOff);

            Assert.AreEqual(null, visibility);
        }
    }
}