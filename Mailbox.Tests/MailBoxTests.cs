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
        [TestMethod()]
        public void ToStringTest_NotPremiumSize()
        {
            //Arrange
            Person owner = new Person("John", "Doe");
            MailBox mailBox = new MailBox(Size.Small, (1,3), owner);
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
            MailBox mailBox = new MailBox(Size.Small | Size.Premium, (1, 3), owner);
            string expectedString = $"Mailbox Owner: {owner.ToString()}, Location: x = 1, y = 3, BoxSize: Small, Premium";

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