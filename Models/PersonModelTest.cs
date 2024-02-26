using Microsoft.VisualStudio.TestTools.UnitTesting;
using Petsy.Models;
using System;

namespace PetsyTests.Models
{
    [TestClass]
    public class PersonModelTest
    {
        [TestMethod]
        public void GetFullName_ReturnsFullName()
        {
            // Arrange
            var person = new Person
            {
                Name = "Ilina",
                Surname = "Dimovska",
                Age = 24
            };

            // Act
            var fullName = person.GetFullName;

            // Assert
            Assert.AreEqual("Ilina Dimovska", fullName);
        }
    }
}
