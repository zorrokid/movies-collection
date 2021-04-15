using Application.UseCases.ImportCsv;

namespace CsvImport
{
    public interface ICsvImportClient
    {
        void Import(string filePath);
    }

    public class CsvImportClient : ICsvImportClient
    {
        private readonly IImportPublicationsUseCase importPublicationsUseCase;

        public CsvImportClient(IImportPublicationsUseCase importPublicationsUseCase)
        {
            this.importPublicationsUseCase = importPublicationsUseCase;
        }

        public void Import(string filePath)
        {
            importPublicationsUseCase.Import(filePath);
        }

    }
}