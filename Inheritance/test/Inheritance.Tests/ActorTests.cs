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

            //Act
            raj.Speak();

            //Assert
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Raj_ActorTest_WomenNotPresent()
        {
            //Arrange
            Actor raj = new Raj(false);

            //Act
            raj.Speak();

            //Assert
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Penny_ActorTest()
        {
            //Arrange
            Actor penny = new Penny();

            //Act
            penny.Speak();

            //Assert
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Sheldon_ActorTest()
        {
            //Arrange
            Actor sheldon = new Sheldon();

            //Act
            sheldon.Speak();

            //Assert
            throw new NotImplementedException();
        }
    }
}
