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
            Raj raj = new Raj(true);

            string say = "Hello";
            string expected = "Raj : ";

            //Act
            string says = raj.Speak(say);
            
            //Assert
            Assert.AreEqual(expected, says);
        }

        [TestMethod]
        public void Raj_ActorTest_WomenNotPresent()
        {
            //Arrange
            Raj raj = new Raj(false);

            string say = "I don't like bugs, okay. They freak me out.";
            string expected = "Raj : I don't like bugs, okay. They freak me out.";

            //Act
            string says = raj.Speak(say);

            //Assert
            Assert.AreEqual(expected, says);
        }

        [TestMethod]
        public void Penny_ActorTest()
        {
            //Arrange
            Penny penny = new Penny();

            string say = "What up, shel-bot?";
            string expected = "Penny : What up, shel-bot?";

            //Act
            string says = penny.Speak(say);

            //Assert
            Assert.AreEqual(expected, says);
        }

        [TestMethod]
        public void Sheldon_ActorTest()
        {
            //Arrange
            Sheldon sheldon = new Sheldon();

            string say = "Interesting. You're afraid of insects and women. Ladybugs must render you catatonic.";
            string expected = "Sheldon : Interesting. You're afraid of insects and women. Ladybugs must render you catatonic.";

            //Act
            string says = sheldon.Speak(say);

            //Assert
            Assert.AreEqual(expected, says);
        }
    }
}
