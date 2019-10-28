using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace Configuration.Tests
{
    [TestClass()]
    public class FileConfigTests
    {
        [TestMethod()]
        public void GetConfigValueTest_ReturnFalse()
        {
            //Arrange
            string filePath = CreateTestFile();
            FileConfig fileConfig = new FileConfig(filePath);
            string name = "SomeNameNotInFile";
            string? value;

            //Act
            bool tf = fileConfig.GetConfigValue(name, out value);

            //Assert
            Assert.IsFalse(tf);
            Assert.AreEqual(null, value);

            File.Delete(filePath);
        }

        [TestMethod()]
        public void GetConfigValueTest_ReturnTrue()
        {
            //Arrange
            string filePath = CreateTestFile();
            FileConfig fileConfig = new FileConfig(filePath);
            string name = "NAME1";
            string? value;

            //Act
            bool tf = fileConfig.GetConfigValue(name, out value);

            //Assert
            Assert.IsTrue(tf);
            Assert.AreEqual("VALUE1", value);

            File.Delete(filePath);
        }

        [TestMethod()]
        public void ParseLineTest_NoException()
        {
            //Arrange
            string line = "NAME=VALUE";
            string expectedName = "NAME", expectedValue = "VALUE";
            FileConfig fileConfig = new FileConfig("");

            //Act
            string[] parsedLine = fileConfig.ParseLine(line);

            //Assert
            Assert.AreEqual(expectedName, parsedLine[0]);
            Assert.AreEqual(expectedValue, parsedLine[1]);
        }

        [TestMethod()]
        public void ParseLineTest_NullException()
        {
            //Arrange
            FileConfig fileConfig = new FileConfig("");

            //Act & Assert
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Assert.ThrowsException<ArgumentNullException>(() => fileConfig.ParseLine(null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }

        [TestMethod()]
        public void SetConfigValueTest_ReturnTrue()
        {
            //Arrange
            string filePath = Path.GetRandomFileName();
            FileConfig fileConfig = new FileConfig(filePath);
            string name = "NAME";
            string? value = "VALUE";

            //Act
            bool tf = fileConfig.SetConfigValue(name, value);
            string[] lines = File.ReadLines(filePath).ToArray();

            //Assert
            Assert.IsTrue(tf);
            Assert.AreEqual(1, lines.Length);
            Assert.AreEqual("NAME=VALUE", lines[0]);

            File.Delete(filePath);
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
            FileConfig fileConfig = new FileConfig("");

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => fileConfig.ValidateNameAndValue(name, value));

        }

        [DataTestMethod]
        [DataRow("NAME", "TESTVALUE")]
        [DataRow("name", "testValue")]
        [DataRow("Name", "testvalue")]
        [TestMethod()]
        public void ValidateNameAndValueTest_NoException(string name, string? value)
        {
            //Arrange
            FileConfig fileConfig = new FileConfig("");

            //Act
            bool tf = fileConfig.ValidateNameAndValue(name, value);

            //Assert
            Assert.IsTrue(tf);
        }

#pragma warning disable CA1822 // Mark members as static
        public string CreateTestFile()
#pragma warning restore CA1822 // Mark members as static
        {
            string filePath = Path.GetRandomFileName();

            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine("NAME1=VALUE1");
                sw.WriteLine("NAME2=VALUE2");
                sw.WriteLine("NAME3=VALUE3");
                sw.WriteLine("NAME4=VALUE4");
            }

            return filePath;
        }
    }
}