using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Tests
{
    [TestClass()]
    public class PersonTests
    {
        [TestMethod()]
        public void Person_ValidData_Succuss()
        {
            //Arrange
            string first = "123 somewhere street", last = "Glendale", email = "AZ";

            //Act
            Person person = new Person(first, last, email, new Address("street", "city", "state", "zip"));

            //Assert
            try
            {
                Assert.AreEqual(first, person.FirstName);
                Assert.AreEqual(last, person.LastName);
                Assert.AreEqual(email, person.EmailAddress);
                Assert.AreEqual("street", person.Address.StreetAddress);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [TestMethod()]
        public void Person_NullFirst_ThrowsArgumentNullException()
        {
            //Arrange, Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Person(null!, "Last", "Email@email.com", new Address("street","city","state","zip")));
        }

        [TestMethod()]
        public void Person_NullLast_ThrowsArgumentNullException()
        {
            //Arrange, Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Person("First", null!, "Email@email.com", new Address("street", "city", "state", "zip")));
        }

        [TestMethod()]
        public void Person_NullEmail_ThrowsArgumentNullException()
        {
            //Arrange, Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Person("First", "Last", null!, new Address("street", "city", "state", "zip")));
        }

        [TestMethod()]
        public void Person_NullAddress_ThrowsArgumentNullException()
        {
            //Arrange, Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Person("First", "Last", "Email@email.com", null!));
        }
    }
}