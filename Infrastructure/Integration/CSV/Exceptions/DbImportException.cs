using System;

namespace Infrastructure.Integration.CSV.Exceptions
{
    public class DbImportException : Exception
    {
        public DbImportException()
        {
        }

        public DbImportException(string message) : base(message)
        {
        }

        public DbImportException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

