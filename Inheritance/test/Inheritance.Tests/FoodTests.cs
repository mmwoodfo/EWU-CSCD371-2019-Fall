using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inheritance.Tests
{
    [TestClass]
    public class FoodTests
    {
        [TestMethod]
        public void Food_DoesPrintInfo()
        {
            //Arrange
            Food food = new Food();
            food.Upc = "123456";
            food.Brand = "Mac n' Cheese";
            string expected = "123456 - Mac n' Cheese";

            //Act
            string info = food.PrintInfo();

            //Assert
            Assert.AreEqual(info, expected);
        }
    }
}
