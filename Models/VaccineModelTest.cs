using Microsoft.VisualStudio.TestTools.UnitTesting;
using Petsy.Models;
using System.Collections.Generic;

namespace PetsyTests.Models
{
    [TestClass]
    public class VaccineModelTest
    {
        [TestMethod]
        public void VaccineProperties_AreSetCorrectly()
        {
            // Arrange
            var pets = new List<Pet>
            {
                new Pet { Id = 1, Name = "Mia", Age = 2 },
                new Pet { Id = 2, Name = "Heli", Age = 1 }
            };

            // Act
            var vaccine = new Vaccine
            {
                Id = 1,
                Name = "Besnilo",
                Pets = pets
            };

            // Assert
            Assert.AreEqual(1, vaccine.Id);
            Assert.AreEqual("Besnilo", vaccine.Name);
            CollectionAssert.AreEqual(pets, vaccine.Pets);
        }
    }
}
