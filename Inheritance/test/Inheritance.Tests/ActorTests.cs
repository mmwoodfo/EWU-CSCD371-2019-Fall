using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Inheritance.Tests
{
    [TestClass]
    public class ActorTests
    {
        [TestMethod]
        public void Raj_ActorTest_WomenPresent()
        {
            //Arrange
            Actor raj = new Raj(true);
            string expected = "Raj : ";

            //Act
            string says = raj.Speak("Hello");

            //Assert
            Assert.AreEqual(expected, says);
        }

        [TestMethod]
        public void Raj_ActorTest_WomenNotPresent()
        {
            //Arrange
            Actor raj = new Raj(false);
            string expected = "Raj : I don't like bugs, okay. They freak me out.";

            //Act
            string says = raj.Speak("I don't like bugs, okay. They freak me out.");

            //Assert
            Assert.AreEqual(expected, says);
        }

        [TestMethod]
        public void Penny_ActorTest()
        {
            //Arrange
            Actor penny = new Penny();
            string expected = "Penny : What up, shel-bot?";

            //Act
            string says = penny.Speak("What up, shel-bot?");

            //Assert
            Assert.AreEqual(expected, says);
        }

        [TestMethod]
        public void Sheldon_ActorTest()
        {
            //Arrange
            Actor sheldon = new Sheldon();
            string expected = "Sheldon : Interesting. You're afraid of insects and women. Ladybugs must render you catatonic.";

            //Act
            string says = sheldon.Speak("Interesting. You're afraid of insects and women. Ladybugs must render you catatonic.");

            //Assert
            Assert.AreEqual(expected, says);
        }
    }
}
