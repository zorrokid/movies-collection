using System;

namespace Application.UseCases.ImportCsv
{
    public class CvsImportException : Exception
    {
        public CvsImportException()
        {
        }

        public CvsImportException(string message) : base(message)
        {
        }

        public CvsImportException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

