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
            Raj raj = new Raj(true);

            raj.Says = "Hello";
            string expected = "Raj : ";

            //Act
            string says = raj.Speak();
            
            //Assert
            Assert.AreEqual(expected, says);
        }

        [TestMethod]
        public void Raj_ActorTest_WomenNotPresent()
        {
            //Arrange
            Raj raj = new Raj(false);

            raj.Says = "I don't like bugs, okay. They freak me out.";
            string expected = "Raj : I don't like bugs, okay. They freak me out.";

            //Act
            string says = raj.Speak();

            //Assert
            Assert.AreEqual(expected, says);
        }

        [TestMethod]
        public void Penny_ActorTest()
        {
            //Arrange
            Penny penny = new Penny();

            penny.Says = "What up, shel-bot?";
            string expected = "Penny : What up, shel-bot?";

            //Act
            string says = penny.Speak();

            //Assert
            Assert.AreEqual(expected, says);
        }

        [TestMethod]
        public void Sheldon_ActorTest()
        {
            //Arrange
            Sheldon sheldon = new Sheldon();

            sheldon.Says = "Interesting. You're afraid of insects and women. Ladybugs must render you catatonic.";
            string expected = "Sheldon : Interesting. You're afraid of insects and women. Ladybugs must render you catatonic.";

            //Act
            string says = sheldon.Speak();

            //Assert
            Assert.AreEqual(expected, says);
        }

        [TestMethod]
        public void NotReal_ActorTest()
        {
            //Arrange
            Actor notReal = new Actor();

            //Assert
            Assert.ThrowsException<ArgumentNullException>(() => notReal.Speak());
        }
    }
}
