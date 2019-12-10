using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Mailbox.Tests
{
    [TestClass()]
    public class DataLoaderTests
    {
        private List<MailBox> _TestMailboxes = new List<MailBox>()
        {
            new MailBox(Sizes.LargePremium, (1, 1), new Person("John", "Doe")),
            new MailBox(Sizes.Small, (15, 5), new Person("Jane", "Doe")),
            new MailBox(Sizes.Medium, (30, 10), new Person("Indiana", "Jones"))
        };

        [TestMethod()]
        public void DataLoader_Exception()
        {
            //Arrange, Act & Assert
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Assert.ThrowsException<ArgumentNullException>(() => new DataLoader(null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

        }

        [TestMethod()]
        public void LoadTest_ExceptionReturnsNull()
        {
            //Arrange
            using var ms = new MemoryStream();
            using (StreamWriter sw = new StreamWriter(ms, leaveOpen: true))
            {
                foreach (MailBox mailbox in _TestMailboxes)
                    sw.WriteLine(mailbox.ToString());
            }
            ms.Position = 0;

            using DataLoader dataLoader = new DataLoader(ms);


            //Act & Assert
            Assert.IsNull(dataLoader.Load());
        }

        [TestMethod()]
        public void LoadTest_NoException()
        {
            //Arrange
            using var ms = new MemoryStream();
            using (StreamWriter sw = new StreamWriter(ms, leaveOpen: true))
            {
                foreach (MailBox mailbox in _TestMailboxes)
                    sw.WriteLine(JsonConvert.SerializeObject(mailbox));
            }
            ms.Position = 0;

            using DataLoader dataLoader = new DataLoader(ms);

            //Act
            List<MailBox>? mailboxes = dataLoader.Load();

            //Assert
            Assert.IsNotNull(mailboxes);
            Assert.AreEqual(_TestMailboxes.Count, mailboxes?.Count);

        }

        [TestMethod()]
        public void SaveTest()
        {
            //Arrange
            List<MailBox> mailboxes = new List<MailBox>();
            using var ms = new MemoryStream();
            using DataLoader dataLoader = new DataLoader(ms);

            //Act
            dataLoader.Save(_TestMailboxes);
            string? jsonLine;

            ms.Position = 0;
            using (StreamReader sr = new StreamReader(ms))
            {
                while ((jsonLine = sr.ReadLine()) != null)
                {
                    mailboxes.Add(JsonConvert.DeserializeObject<MailBox>(jsonLine));
                }
            }

            //Assert
            Assert.AreEqual(3, mailboxes.Count);
        }
    }
}