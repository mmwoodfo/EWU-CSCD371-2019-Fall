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