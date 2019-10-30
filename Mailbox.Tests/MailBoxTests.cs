﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            string expectedString = $"{owner.ToString()} : (1, 3) : Small";

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
            string expectedString = $"{owner.ToString()} : (1, 3) : Small, Premium";

            //Act
            string receivedString = mailBox.ToString();

            //Assert
            Assert.AreEqual(expectedString, receivedString);
        }
    }
}