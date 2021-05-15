using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using Infrastructure.Integration.CSV.Importers;
using Infrastructure.Integration.CSV.Models;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Integration.CSV.Readers
{
    public class CsvReader<TClassMap, TRowModel> : ICsvReader
        where TClassMap : ClassMap<CsvRow>
    {
        private readonly ICsvImporter<TRowModel> csvImporter;
        private readonly ILogger<CsvReader<TClassMap, TRowModel>> logger;

        public CsvReader(ICsvImporter<TRowModel> csvImporter, ILogger<CsvReader<TClassMap, TRowModel>> logger)
        {
            this.csvImporter = csvImporter;
            this.logger = logger;
        }

        public void ReadCsv(string filePath, string delimiter)
        {   
            logger.LogInformation($"Reading csv from file {filePath}");
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = delimiter
            };
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Context.RegisterClassMap<TClassMap>();
                var records = csv.GetRecords<TRowModel>();
                foreach (var record in records)
                {
                    logger.LogTrace($"Importing record {record}");
                    csvImporter.Import(record);
                }
                csvImporter.Complete();
            }
        }
    }
}