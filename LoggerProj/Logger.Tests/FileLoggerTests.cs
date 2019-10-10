﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            FileLogger fileLogger = new FileLogger(filePath);

            //Assert
            Assert.IsTrue(File.Exists(filePath));

            File.Delete(filePath);
        }

        [TestMethod]
        public void LogMessage_DidAddLog_Success()
        {
            //Arrange
            string filePath = Path.GetRandomFileName();
            FileLogger fileLogger = new FileLogger(filePath);

            //Act
            fileLogger.Log(LogLevel.Information, "Test Message");
            int lineCount = File.ReadLines(filePath).Count();

            //Assert
            Assert.AreEqual(1, lineCount);

            File.Delete(filePath);
        }
    }
}
