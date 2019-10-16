using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inheritance.Tests
{
    [TestClass]
    public class TelevisionTests
    {
        [TestMethod]
        public void Television_DoesPrintInfo()
        {
            //Arrange
            Television tv = new Television();
            tv.Manufacturer = "Samsung";
            tv.Size = "55\"";
            string expected = "Samsung - 55\"";

            //Act
            string info = tv.PrintInfo();

            //Assert
            Assert.AreEqual(info, expected);
        }
    }
}
