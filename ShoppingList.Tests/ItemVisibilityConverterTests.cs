using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingList.Tests
{
    [TestClass()]
    public class ItemVisibilityConverterTests
    {
        [TestMethod()]
        public void Convert_GivenItemObject_ReturnVisible()
        {
            //Arrange
            ItemVisibilityConverter visibilityConverter = new ItemVisibilityConverter();
            Item item = new Item("Apples");

            string visibility = (string)visibilityConverter.Convert(item);

            Assert.AreEqual("Visible", visibility);
        }
    }
}