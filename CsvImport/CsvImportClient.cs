using Application.Interfaces;
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
        private readonly IIntegration integration;
        
        public CsvImportClient(ILogger logger, IIntegration integration)
        {
            this.logger = logger;
            this.integration = integration;
        }

        public void Import(string filePath)
        {
            logger.LogDebug($"Starting import from filepath {filePath}");
            integration.ImportPublications(filePath);
        }

    }
}