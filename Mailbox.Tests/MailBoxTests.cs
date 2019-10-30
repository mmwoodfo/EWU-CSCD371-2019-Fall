using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mailbox;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailbox.Tests
{
    [TestClass()]
    public class MailBoxTests
    {
        [DataTestMethod]
        [DataRow(100,100)]
        [DataRow(31,5)]
        [DataRow(5,11)]
        [DataRow(0,5)]
        [DataRow(5,0)]
        [DataRow(5,-1)]
        [DataRow(-1,5)]
        [TestMethod()]
        public void MailBoxConstructorTest_InvalidLocation(int x, int y)
        {
            //Arrange
            Sizes size = Sizes.Small;
            ValueTuple<int, int> location = new ValueTuple<int,int>(x, y);
            Person person = new Person("First Name", "Last Name");

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new MailBox(size, location, person));
            Assert.ThrowsException<ArgumentException>(() => new MailBox(location, person));
        }

        [DataTestMethod]
        [DataRow(30,10)]
        [DataRow(10,5)]
        [DataRow(1,1)]
        [DataRow(30,9)]
        [DataRow(29,10)]
        [DataRow(1, 2)]
        [DataRow(2,1)]
        [TestMethod()]
        public void MailBoxConstructorTest_ValidLocation(int x, int y)
        {
            //Arrange
            Sizes size = Sizes.Small;
            ValueTuple<int, int> location = new ValueTuple<int, int>(x, y);
            Person person = new Person("First Name", "Last Name");

            //Act
            MailBox mailbox1 = new MailBox(size, location, person);
            MailBox mailbox2 = new MailBox(location, person);

            //Assert
            Assert.AreEqual(mailbox1.Location, (x, y));
            Assert.AreEqual(mailbox2.Location, (x, y));
        }

        [TestMethod]
        public void MailBoxConstrucotrTest_SizePremium()
        {
            //Arrange
            Sizes size = Sizes.Premium;
            ValueTuple<int, int> location = new ValueTuple<int, int>(15, 5);
            Person person = new Person("First Name", "Last Name");

            //Act
            MailBox mailbox = new MailBox(size, location, person);

            //Assert
            Assert.AreEqual(mailbox.MailSize, Sizes.Unspecfied);
        }

        [TestMethod]
        public void MailBoxConstrucotrTest_SizeNotPremium()
        {
            //Arrange
            Sizes size = Sizes.PremiumSmall;
            ValueTuple<int, int> location = new ValueTuple<int, int>(15, 5);
            Person person = new Person("First Name", "Last Name");

            //Act
            MailBox mailbox = new MailBox(size, location, person);

            //Assert
            Assert.AreEqual(mailbox.MailSize, Sizes.PremiumSmall);
        }

        [TestMethod()]
        public void ToStringTest_NotPremiumSize()
        {
            //Arrange
            Person owner = new Person("John", "Doe");
            MailBox mailBox = new MailBox(Sizes.Small, (1,3), owner);
            string expectedString = $"Mailbox Owner: {owner.ToString()}, Location: x = 1, y = 3, BoxSize: Small";

            //Act
            string receivedString = mailBox.ToString();

            //Assert
            Assert.AreEqual(expectedString, receivedString);
        }

        [TestMethod()]
        public void ToStringTest_PremiumSize()
        {
            //Arrange
            Person owner = new Person("John", "Doe");
            MailBox mailBox = new MailBox(Sizes.PremiumSmall, (1, 3), owner);
            string expectedString = $"Mailbox Owner: {owner.ToString()}, Location: x = 1, y = 3, BoxSize: PremiumSmall";

            //Act
            string receivedString = mailBox.ToString();

            //Assert
            Assert.AreEqual(expectedString, receivedString);
        }

        [TestMethod()]
        public void ToStringTest_NoSize()
        {
            //Arrange
            Person owner = new Person("John", "Doe");
            MailBox mailBox = new MailBox((1, 3), owner);
            string expectedString = $"Mailbox Owner: {owner.ToString()}, Location: x = 1, y = 3";

            //Act
            string receivedString = mailBox.ToString();

            //Assert
            Assert.AreEqual(expectedString, receivedString);
        }
    }
}