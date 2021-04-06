using System;

namespace Application.UseCases.ImportCsv
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

