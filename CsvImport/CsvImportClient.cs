using Application.UseCases.ImportCsv;
using Microsoft.Extensions.Logging;

namespace CsvImport
{
    public interface ICsvImportClient
    {
        void Import(string filePath);
    }

    public class CsvImportClient : ICsvImportClient
    {
        private readonly ILogger logger;
        private readonly IImportPublicationsUseCase importPublicationsUseCase;

        public CsvImportClient(ILogger logger, IImportPublicationsUseCase importPublicationsUseCase)
        {
            this.logger = logger;
            this.importPublicationsUseCase = importPublicationsUseCase;
        }

        public void Import(string filePath)
        {
            logger.LogDebug($"Starting import from filepath {filePath}");
            importPublicationsUseCase.Import(filePath);
        }

    }
}