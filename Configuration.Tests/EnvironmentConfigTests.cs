using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Configuration.Tests
{
    [TestClass()]
    public class EnvironmentConfigTests
    {
        [TestMethod]

        public void EnvironmentConfig_GetConfigValue_ReturnsFalse()
        {
            //arrange
            string name = "Wrong Path Name";
            string? value = "TESTVALUE";
            EnvironmentConfig testSystem = new EnvironmentConfig();

            //act
            bool tf = testSystem.GetConfigValue(name, out value);

            //assert
            Assert.IsFalse(tf);
            Assert.IsNull(value);
        }

        [TestMethod]
        public void EnvironmentConfig_GetConfigValue_ReturnsTrue()
        {
            //arrange
            string name = "TEMP";
            string? value = "TESTVALUE";
            EnvironmentConfig testSystem = new EnvironmentConfig();

            //act
            bool tf = testSystem.GetConfigValue(name, out value);

            //assert
            Assert.IsTrue(tf);
            Assert.IsNotNull(value);
        }

        [TestMethod]
        public void EnvironmentConfig_SetConfigValue_ReturnsFalse()
        {
            //arrange
            string name = "Wrong Path Name";
            string? value = null;
            EnvironmentConfig testSystem = new EnvironmentConfig();

            //act
            bool tf = testSystem.SetConfigValue(name, value);

            //assert
            Assert.IsFalse(tf);
        }

        [TestMethod]
        public void EnvironmentConfig_SetConfigValue_ReturnsTrue()
        {
            //arrange
            string name = "TEMP", value = "TESTVALUE";
            string? valueOut;
            EnvironmentConfig testSystem = new EnvironmentConfig();

            //act
            bool tf = testSystem.SetConfigValue(name, value);
            testSystem.GetConfigValue(name, out valueOut);

            //assert
            Assert.IsTrue(tf);
            Assert.IsNotNull(value);
        }
    }
}
