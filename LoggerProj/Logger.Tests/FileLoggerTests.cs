using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void LogMessage_DidCreateFile_Success()
        {
            //Arrange
            string filePath = Path.GetRandomFileName();

            //Act
            try
            {
                FileLogger fileLogger = new FileLogger(filePath);

                //Assert
                Assert.IsTrue(File.Exists(filePath));
            }
            finally
            {
                File.Delete(filePath);
            }
        }

        [TestMethod]
        public void LogMessage_DidAddLog_Success()
        {
            //Arrange
            string filePath = Path.GetRandomFileName();
            FileLogger fileLogger = new FileLogger(filePath);

            try
            {
                //Act
                fileLogger.Log(LogLevel.Information, "Test Message 1");
                fileLogger.Log(LogLevel.Warning, "Test Message 2");
                fileLogger.Log(LogLevel.Error, "Test Message 3");
                fileLogger.Log(LogLevel.Debug, "Test Message 4");
                string[] lines = File.ReadLines(filePath).ToArray();

                //Assert
                Assert.IsTrue(lines[0].Contains("Test Message 1"));
                Assert.IsTrue(lines[1].Contains("Test Message 2"));
                Assert.IsTrue(lines[2].Contains("Test Message 3"));
                Assert.IsTrue(lines[3].Contains("Test Message 4"));
                Assert.AreEqual(4, lines.Length);
            }
            finally
            {
                File.Delete(filePath);
            }
        }
    }
}
