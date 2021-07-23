using Application.Interfaces;
using Infrastructure.Integration.CSV.Importers;
using Infrastructure.Integration.CSV.Models;
using Infrastructure.Integration.CSV.Readers;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Integration
{
    public class IntegrationService : IIntegration
    {
        private readonly ICsvReader<CsvRow> reader;
        private readonly ICsvImporter csvImporter;
        private readonly ILogger<IntegrationService> logger;

        public IntegrationService(ICsvReader<CsvRow> reader, ICsvImporter csvImporter, ILogger<IntegrationService> logger)
        {
            this.reader = reader;
            this.csvImporter = csvImporter;
            this.logger = logger;
        }

        public void ImportPublications(string resourcePath)
        {
            logger.LogInformation($"Start reading from {resourcePath}.");
            var records = reader.ReadCsv(resourcePath);
            logger.LogInformation($"Start import from csv source.");
            csvImporter.Import(records);
            logger.LogInformation($"Finished import from csv source.");
        }
    }
}