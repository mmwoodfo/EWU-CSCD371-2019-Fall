using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MockConfig.Tests
{
    [TestClass()]
    public class MockConfigTests
    {
        [TestMethod]
        public void MockConfig_GetConfigValue_ReturnsFalse()
        {
            //arrange
            string name = "Wrong Path Name", value = "TESTVALUE";
            MockConfig testSystem = new MockConfig(true);

            //act
            bool tf = testSystem.GetConfigValue(name, out value);

            //assert
            Assert.IsFalse(tf);
        }

        [DataTestMethod]
        [DataRow("NAME1", "TESTVALUE")]
        [DataRow("NAME2", "TESTVALUE")]
        [DataRow("NAME3", "TESTVALUE")]
        [DataRow("NAME4", "TESTVALUE")]
        public void MockConfig_GetConfigValue_ReturnsTrue(string name, string value)
        {
            //arrange
            MockConfig testSystem = new MockConfig(true);

            //act
            bool tf = testSystem.GetConfigValue(name, out value);

            //assert
            Assert.IsTrue(tf);
        }

        [DataTestMethod]
        [DataRow(null, "TESTVALUE")]
        [DataRow("NAME", null)]
        [DataRow("N AM E", "TESTVALUE")]
        [DataRow("NAME ", "TESTVALUE")]
        [DataRow("N=AME", "TESTVALUE")]
        [DataRow("=N=A=M=E", "TESTVALUE")]
        [DataRow("NAME", "TEST VALUE")]
        [DataRow("NAME", "TEST VALUE ")]
        [DataRow("NAME", "TEST=VALUE")]
        [DataRow("NAME", "TEST=VALUE=")]
        [DataRow("N AME", "TEST=VALUE")]
        [TestMethod()]
        public void ValidateNameAndValueTest_ThrowsArgumentException(string name, string? value)
        {
            //Arrange
            MockConfig testSystem = new MockConfig(false);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => testSystem.ValidateNameAndValue(name, value));

        }

        [DataTestMethod]
        [DataRow("NAME", "TESTVALUE")]
        [DataRow("name", "testValue")]
        [DataRow("Name", "testvalue")]
        [TestMethod()]
        public void ValidateNameAndValueTest_NoException(string name, string? value)
        {
            //Arrange
            MockConfig testSystem = new MockConfig(false);

            //Act
            bool tf = testSystem.ValidateNameAndValue(name, value);

            //Assert
            Assert.IsTrue(tf);
        }

        [DataTestMethod]
        [DataRow("NAME5", "VALUE5")]
        [DataRow("NAME6", "VALUE6")]
        [DataRow("NAME7", "VALUE7")]
        [TestMethod]
        public void MockConfig_SetConfigValue_ReturnsTrue(string name, string value)
        {
            //arrange
            MockConfig testSystem = new MockConfig(false);

            //act
            bool tf = testSystem.SetConfigValue(name, value);

            //assert
            Assert.IsTrue(tf);
        }
    }
}