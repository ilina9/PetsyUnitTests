using Microsoft.VisualStudio.TestTools.UnitTesting;
using Petsy.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetsyTests.Models
{
    [TestClass]
    public class PetModelTest
    {
        [TestMethod]
        public void PetProperties_AreSetCorrectly()
        {
            // Arrange
            var person = new Person
            {
                Id = 1,
                Name = "Ilina",
                Surname = "Dimovska",
                Age = 24
            };

            var vaccines = new List<Vaccine>
            {
                new Vaccine { Id = 1, Name = "Besnilo" },
                new Vaccine { Id = 2, Name = "Zarazni bolesti" }
            };

            // Act
            var pet = new Pet
            {
                Id = 1,
                Name = "Mia",
                Description = "Border Dzuki <3",
                Age = 2,
                PersonId = person.Id,
                Person = person,
                Vaccines = vaccines
            };

            // Assert
            Assert.AreEqual(1, pet.Id);
            Assert.AreEqual("Mia", pet.Name);
            Assert.AreEqual("Border Dzuki <3", pet.Description);
            Assert.AreEqual(2, pet.Age);
            Assert.AreEqual(1, pet.PersonId);
            Assert.AreEqual(person, pet.Person);
            CollectionAssert.AreEqual(vaccines, pet.Vaccines);
        }

        [TestMethod]
        public void AgeValidation_PetAgeWithinRange_IsValid()
        {
            // Arrange
            var pet = new Pet
            {
                Age = 25
            };

            // Act
            var validationContext = new ValidationContext(pet);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(pet, validationContext, validationResults, true);

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void AgeValidation_PetAgeOutOfRange_IsInvalid()
        {
            // Arrange
            var pet = new Pet
            {
                Age = 55
            };

            // Act
            var validationContext = new ValidationContext(pet);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(pet, validationContext, validationResults, true);

            // Assert
            Assert.IsFalse(isValid);

            Assert.IsTrue(validationResults.Any(result => result.ErrorMessage.Contains("Pet age must be between 0 and 50.")));
        }

    }
}
