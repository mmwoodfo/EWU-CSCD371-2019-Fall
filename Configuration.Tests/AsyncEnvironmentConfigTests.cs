using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Configuration.Tests
{
    [TestClass()]
    public class AsyncEnvironmentConfigTests
    {
        // MMM Comment: Wow... async tests.  Cool!
        [TestMethod()]
        public async Task GetConfigValueTest_ReturnFalseAsync()
        {
            //arrange
            string name = "Wrong Path Name";
            // MMM Commenet: Assigment is pointless here as it is reassigned.s
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