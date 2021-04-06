using System;
using System.Linq;

namespace Application.Extensions
{
    public static class StringExtensions
    {
        public static string GivenName(this String fullName)
        {
            var nameParts = fullName.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (nameParts.Length == 0 || nameParts.Length == 1) return "";
            return nameParts[0];
        }

        public static string FamilyName(this String fullName)
        {
            var nameParts = fullName.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (nameParts.Length == 0) return "";
            if (nameParts.Length == 1) return nameParts[0];

            var lastNameParts = nameParts.Skip(1);
            return String.Join(' ', lastNameParts);
        }
    }
}