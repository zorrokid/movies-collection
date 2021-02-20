using Application.UseCases.ImportCsv;

namespace CsvImport
{
    public class CsvImportClient
    {
        private readonly IImportCsvUseCase imprtCsvUseCase;

        public CsvImportClient(IImportCsvUseCase imprtCsvUseCase)
        {
            this.imprtCsvUseCase = imprtCsvUseCase;
        }

        public void Import()
        {
            imprtCsvUseCase.ImportCsv();
        }

    }
}