using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Mailbox.Tests
{
    [TestClass()]
    public class BogusMailBoxTests
    {
        [TestMethod]
        public void MailBoxConstrucotrTest_SizePremium()
        {
            //Arrange, Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new MailBox(Sizes.Premium, (new Random().Next(50), new Random().Next(50)), new Person(new Bogus.DataSets.Name().FirstName(), new Bogus.DataSets.Name().LastName())));
        }

        [TestMethod]
        public void MailBoxConstrucotrTest_SizeNotPremium()
        {
            //Arrange
            Person owner = new Person(new Bogus.DataSets.Name().FirstName(), new Bogus.DataSets.Name().LastName());

            //Act
            MailBox mailbox = new MailBox(Sizes.SmallPremium, (new Random().Next(50), new Random().Next(50)), owner);

            //Assert
            Assert.AreEqual(mailbox.MailSize, Sizes.SmallPremium);
        }

        [TestMethod()]
        public void ToStringTest_NotPremiumSize()
        {
            //Arrange
            Person owner = new Person(new Bogus.DataSets.Name().FirstName(), new Bogus.DataSets.Name().LastName());
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
            Person owner = new Person(new Bogus.DataSets.Name().FirstName(), new Bogus.DataSets.Name().LastName());
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
            Person owner = new Person(new Bogus.DataSets.Name().FirstName(), new Bogus.DataSets.Name().LastName());
            MailBox mailBox = new MailBox(Sizes.Unspecfied, (1, 3), owner);
            string expectedString = $"Mailbox Owner: {owner.ToString()}, Location: x = 1, y = 3";

            //Act
            string receivedString = mailBox.ToString();

            //Assert
            Assert.AreEqual(expectedString, receivedString);
        }
    }
}