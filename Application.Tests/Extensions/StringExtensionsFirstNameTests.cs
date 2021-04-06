using NUnit.Framework;
using Application.Extensions;

namespace Application.Tests.Extensions
{
    public class StringExtension_FirstName_Tests
    {
        [Test]
        public void NameIsEmpty_ReturnsEmptyString()
        {
            var fullName = "";
            var lastName = fullName.FamilyName();
            Assert.AreEqual("", lastName);
        }

        [Test]
        public void NameHasOneWord_ReturnsTheOnlyWord()
        {
            var fullName = "Lastname";
            var lastName = fullName.FamilyName();
            Assert.AreEqual(fullName, lastName);
        }

        [Test]
        public void NameHasTwoWords_ReturnsSecondWord()
        {
            var expectedLastName = "Firstname";
            var fullName = $"Firstname {expectedLastName}" ;
            var lastName = fullName.FamilyName();
            Assert.AreEqual(expectedLastName, lastName);
        }

        [Test]
        public void NameHasMultipleWords_ReturnsEverythingButFirstWord()
        {
            var expectedLastName = "Middlename von Lastname";
            var fullName = $"Firstname {expectedLastName}";
            var lastName = fullName.FamilyName();
            Assert.AreEqual(expectedLastName, lastName);
        }
    }
}