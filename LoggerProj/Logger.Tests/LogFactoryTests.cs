using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void CreateLogger_NotConfigured_ReturnNull()
        {
            //Arrange
            LogFactory logFactory = new LogFactory();

            //Act
            BaseLogger baseLogger = logFactory.CreateLogger("Test");

            //Assert
            Assert.IsNull(baseLogger);
        }

        [TestMethod]
        public void CreateLogger_Configured_ReturnBaseLogger()
        {
            //Arrange
            LogFactory logFactory = new LogFactory();
            logFactory.ConfigureFileLogger("TestPath.txt");

            //Act
            BaseLogger nullBaseLogger = logFactory.CreateLogger("Test");

            //Assert
            Assert.IsNotNull(nullBaseLogger);
        }
    }
}
