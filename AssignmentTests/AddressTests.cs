using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Tests
{
    [TestClass()]
    public class AddressTests
    {
        [TestMethod()]
        public void Address_ValidData_Succuss()
        {
            //Arrange
            string street = "123 somewhere street", city = "Glendale", state = "AZ", zip = "54321";

            //Act
            Address address = new Address(street, city, state, zip);

            //Assert
            try
            {
                Assert.AreEqual(street, address.StreetAddress);
                Assert.AreEqual(city, address.City);
                Assert.AreEqual(state, address.State);
                Assert.AreEqual(zip, address.Zip);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [TestMethod()]
        public void Address_NullStreet_ThrowsArgumentNullException()
        {
            //Arrange, Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Address(null!, "city", "state", "zip"));
        }

        [TestMethod()]
        public void Address_NullCity_ThrowsArgumentNullException()
        {
            //Arrange, Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Address("street", null!, "state", "zip"));
        }

        [TestMethod()]
        public void Address_NullState_ThrowsArgumentNullException()
        {
            //Arrange, Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Address("street", "city", null!, "zip"));
        }

        [TestMethod()]
        public void Address_NullZip_ThrowsArgumentNullException()
        {
            //Arrange, Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Address("street", "city", "state", null!));
        }
    }
}