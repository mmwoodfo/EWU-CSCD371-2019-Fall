using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inheritance.Tests
{
    [TestClass]
    public class ActorTests
    {
        [TestMethod]
        public void Raj_ActorTest_WomenPresent()
        {
            //Arrange
            Raj raj = new Raj(true)
            {
                Say = "Hello"
            };

            string expected = "Raj : ";

            //Act
            string says = raj.Speak(raj.Say);

            //Assert
            Assert.AreEqual(expected, says);
        }

        [TestMethod]
        public void Raj_ActorTest_WomenNotPresent()
        {
            //Arrange
            Raj raj = new Raj(false)
            {
                Say = "I don't like bugs, okay. They freak me out."
            };

            string expected = "Raj : I don't like bugs, okay. They freak me out.";

            //Act
            string says = raj.Speak(raj.Say);

            //Assert
            Assert.AreEqual(expected, says);
        }

        [TestMethod]
        public void Penny_ActorTest()
        {
            //Arrange
            Penny penny = new Penny
            {
                Say = "What up, shel-bot?"
            };

            string expected = "Penny : What up, shel-bot?";

            //Act
            string says = penny.Speak(penny.Say);

            //Assert
            Assert.AreEqual(expected, says);
        }

        [TestMethod]
        public void Sheldon_ActorTest()
        {
            //Arrange
            Sheldon sheldon = new Sheldon
            {
                Say = "Interesting. You're afraid of insects and women. Ladybugs must render you catatonic."
            };

            string expected = "Sheldon : Interesting. You're afraid of insects and women. Ladybugs must render you catatonic.";

            //Act
            string says = sheldon.Speak(sheldon.Say);

            //Assert
            Assert.AreEqual(expected, says);
        }
    }
}
