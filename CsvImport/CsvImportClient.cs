using Application.UseCases.ImportCsv;

namespace CsvImport
{
    public interface ICsvImportClient
    {
        void Import(string filePath);
    }

    public class CsvImportClient : ICsvImportClient
    {
        private readonly IImportCsvUseCase imprtCsvUseCase;

        public CsvImportClient(IImportCsvUseCase imprtCsvUseCase)
        {
            this.imprtCsvUseCase = imprtCsvUseCase;
        }

        public void Import(string filePath)
        {
            imprtCsvUseCase.ImportCsv(filePath);
        }

    }
}