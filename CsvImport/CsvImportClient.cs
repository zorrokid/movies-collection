using System.Collections.Generic;
using Application.UseCases.ImportCsv;
using Application.UseCases.ReadCsv;

namespace CsvImport
{
    public interface ICsvImportClient
    {
        void Import(string filePath);
    }

    public class CsvImportClient : ICsvImportClient
    {
        private readonly IReadCsvUseCase readCsvUseCase;
        private readonly IImportCsvUseCase importCsvUseCase;

        public CsvImportClient(IReadCsvUseCase readCsvUseCase, IImportCsvUseCase importCsvUseCase)
        {
            this.readCsvUseCase = readCsvUseCase;
            this.importCsvUseCase = importCsvUseCase;
        }

        public void Import(string filePath)
        {
            readCsvUseCase.ReadCsv(filePath);
        }

    }
}