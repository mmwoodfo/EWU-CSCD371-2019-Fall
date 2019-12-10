using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
            (int, int) location = (15, 5);
            Person person = new Person("First Name", "Last Name");

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new MailBox(size, location, person));
        }

        [TestMethod]
        public void MailBoxConstrucotrTest_SizeNotPremium()
        {
            //Arrange
            Sizes size = Sizes.SmallPremium;
            ValueTuple<int, int> location = new ValueTuple<int, int>(15, 5);
            Person person = new Person("First Name", "Last Name");

            //Act
            MailBox mailbox = new MailBox(size, location, person);

            //Assert
            Assert.AreEqual(mailbox.MailSize, Sizes.SmallPremium);
        }

        [TestMethod()]
        public void ToStringTest_NotPremiumSize()
        {
            //Arrange
            Person owner = new Person("John", "Doe");
            MailBox mailBox = new MailBox(Sizes.Small, (1, 3), owner);
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
            MailBox mailBox = new MailBox(Sizes.MediumPremium, (1, 3), owner);
            string expectedString = $"Mailbox Owner: {owner.ToString()}, Location: x = 1, y = 3, BoxSize: MediumPremium";

            //Act
            string receivedString = mailBox.ToString();

            //Assert
            Assert.AreEqual(expectedString, receivedString);
        }

        [TestMethod()]
        public void ToStringTest_UnspecifiedSize()
        {
            //Arrange
            Person owner = new Person("John", "Doe");
            MailBox mailBox = new MailBox(Sizes.Unspecfied, (1, 3), owner);
            string expectedString = $"Mailbox Owner: {owner.ToString()}, Location: x = 1, y = 3";

            //Act
            string receivedString = mailBox.ToString();

            //Assert
            Assert.AreEqual(expectedString, receivedString);
        }
    }
}