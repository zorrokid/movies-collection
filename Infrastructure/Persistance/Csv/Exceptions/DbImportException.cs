using System;

namespace Infrastructure.Persistance.Csv.Exceptions
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
