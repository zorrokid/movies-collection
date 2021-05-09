using System;

namespace Infrastructure.Persistence.Csv.Exceptions
{
    public class CsvImportException : Exception
    {
        public CsvImportException()
        {
        }

        public CsvImportException(string message) : base(message)
        {
        }

        public CsvImportException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

