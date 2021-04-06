using System;

namespace Application.UseCases.ReadCsv
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

