using NUnit.Framework;
using Application.Extensions;

namespace Application.Tests.Extensions
{
    public class StringExtension_LastName_Tests
    {
        [Test]
        public void NameIsEmpty_ReturnsEmptyString()
        {
            var fullName = "";
            var firstName = fullName.GivenName();
            Assert.AreEqual("", firstName);
        }

        [Test]
        public void NameHasOneWord_ReturnsEmptyString()
        {
            var fullName = "Lastname";
            var firstName = fullName.GivenName();
            Assert.AreEqual("", firstName);
        }

        [Test]
        public void NameTwoWords_ReturnFirstWord()
        {
            var expectedFirstName = "Firstname";
            var fullName = $"{expectedFirstName} Lastname";
            var firstName = fullName.GivenName();
            Assert.AreEqual(expectedFirstName, firstName);
        }

        [Test]
        public void NameHasTwoWordsWithEmptySpacePaddings_ReturnFirstWordTrimmed()
        {
            var expectedFirstName = "Firstname";
            var fullName = $"   {expectedFirstName}    Lastname   ";
            var firstName = fullName.GivenName();
            Assert.AreEqual(expectedFirstName, firstName);
        }

        [Test]
        public void NameHasMultipleWords_ReturnFirstWord()
        {
            var expectedFirstName = "Firstname";
            var fullName = $"{expectedFirstName} Middlename von Lastname";
            var firstName = fullName.GivenName();
            Assert.AreEqual(expectedFirstName, firstName);
        }
         
    }
}