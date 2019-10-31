using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Mailbox.Tests
{
    [TestClass()]
    public class DataLoaderTests
    {
        [TestMethod()]
        public void LoadTest_Exception()
        {
            ////Arrange
            

            //Act


            //Assert
            
        }

        [TestMethod()]
        public void LoadTest_NoException()
        {
            //Arrange
            string filePath = Path.GetRandomFileName();
            DataLoader dataLoader = new DataLoader(CreateTestJsonFile(filePath));

            try
            {
                //Act
                List<MailBox>? mailboxes = dataLoader.Load();

                //Assert
                Assert.IsNotNull(mailboxes);
            }
            finally
            {
                File.Delete(filePath);
                dataLoader.Dispose();
            }

        }

        [TestMethod()]
        public void SaveTest()
        {
            //Arrange
            List<MailBox> mailboxes = new List<MailBox>(){
                new MailBox(Sizes.Small, (1,1), new Person("John", "Doe")),
                new MailBox(Sizes.PremiumLarge, (15, 5), new Person("Jane", "Doe")),
                new MailBox(Sizes.PremiumLarge, (30, 10), new Person("Indiana", "Jones"))
            };

            string filePath = Path.GetRandomFileName();
            Stream fileStream = File.Open(filePath, FileMode.Create);

            try
            {
                DataLoader dataLoader = new DataLoader(fileStream);

                //Act
                dataLoader.Save(mailboxes);
                string[] lines = File.ReadLines(filePath).ToArray();

                //Assert
                Assert.AreEqual(3, lines.Length);
                Assert.AreEqual(lines[0], JsonConvert.SerializeObject(mailboxes[0]));
                Assert.AreEqual(lines[1], JsonConvert.SerializeObject(mailboxes[1]));
                Assert.AreEqual(lines[2], JsonConvert.SerializeObject(mailboxes[2]));

            }
            finally
            {
                File.Delete(filePath);
                fileStream.Dispose();
            }

        }

        public Stream CreateTestJsonFile(string filePath)
        {
            Stream fileStream = File.Open(filePath, FileMode.Create);

            using (StreamWriter sw = new StreamWriter(fileStream, leaveOpen:true))
            {
                MailBox mailbox1 = new MailBox(Sizes.PremiumLarge, (1,1), new Person("John", "Doe"));
                MailBox mailbox2 = new MailBox(Sizes.PremiumLarge, (15, 5), new Person("Jane", "Doe"));
                MailBox mailbox3 = new MailBox(Sizes.PremiumLarge, (30, 10), new Person("Indiana", "Jones"));
                sw.WriteLine(JsonConvert.SerializeObject(mailbox1));
                sw.WriteLine(JsonConvert.SerializeObject(mailbox2));
                sw.WriteLine(JsonConvert.SerializeObject(mailbox3));
            }

            fileStream.Position = 0;

            return fileStream;
        }
    }
}