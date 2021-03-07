using Application.UseCases.ReadCsv;

namespace CsvImport
{
    public interface ICsvImportClient
    {
        void Import(string filePath);
    }

    public class CsvImportClient : ICsvImportClient
    {
        private readonly IReadCsvUseCase imprtCsvUseCase;

        public CsvImportClient(IReadCsvUseCase imprtCsvUseCase)
        {
            this.imprtCsvUseCase = imprtCsvUseCase;
        }

        public void Import(string filePath)
        {
            imprtCsvUseCase.ImportCsv(filePath);
        }

    }
}