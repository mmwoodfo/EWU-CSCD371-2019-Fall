using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Configuration.Tests
{
    [TestClass()]
    public class AsyncEnvironmentConfigTests
    {
        [TestMethod()]
        public async Task GetConfigValueTest_ReturnFalseAsync()
        {
            //arrange
            string name = "Wrong Path Name";
            string? value = "TESTVALUE";
            AsyncEnvironmentConfig testSystem = new AsyncEnvironmentConfig();

            //act
            bool task = await testSystem.GetConfigValue(name, out value).ConfigureAwait(false);

            //assert
            Assert.IsFalse(task);
            Assert.IsNull(value);
        }

        [TestMethod]
        public async Task EnvironmentConfig_GetConfigValue_ReturnsTrue()
        {
            //arrange
            string name = "TEMP";
            string? value = "TESTVALUE";
            AsyncEnvironmentConfig testSystem = new AsyncEnvironmentConfig();

            //act
            bool task = await testSystem.GetConfigValue(name, out value).ConfigureAwait(false);

            //assert
            Assert.IsTrue(task);
            Assert.IsNotNull(value);
        }

        [TestMethod]
        public async Task EnvironmentConfig_SetConfigValue_ReturnsFalse()
        {
            //arrange
            string name = "Wrong Path Name";
            string? value = null;
            AsyncEnvironmentConfig testSystem = new AsyncEnvironmentConfig();

            //act
            bool task = await testSystem.SetConfigValue(name, value).ConfigureAwait(false);

            //assert
            Assert.IsFalse(task);
        }

        [TestMethod]
        public async Task EnvironmentConfig_SetConfigValue_ReturnsTrue()
        {
            //arrange
            string name = "TEMP", value = "TESTVALUE";
            string? valueOut;
            AsyncEnvironmentConfig testSystem = new AsyncEnvironmentConfig();

            //act
            bool task = await testSystem.SetConfigValue(name, value).ConfigureAwait(false);
            await testSystem.GetConfigValue(name, out valueOut).ConfigureAwait(false);

            //assert
            Assert.IsTrue(task);
            Assert.IsNotNull(value);
        }
    }
}