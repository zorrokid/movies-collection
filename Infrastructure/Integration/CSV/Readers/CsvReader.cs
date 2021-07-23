using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using Infrastructure.Integration.CSV.Importers;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Integration.CSV.Readers
{
    public class CsvReader<TClassMap, TRowModel> : ICsvReader<TRowModel>
        where TClassMap : ClassMap<TRowModel>
    {
        private readonly ICsvImporter csvImporter;
        private readonly ILogger<CsvReader<TClassMap, TRowModel>> logger;

        public CsvReader(ILogger<CsvReader<TClassMap, TRowModel>> logger)
        {
            this.logger = logger;
        }

        public IEnumerable<TRowModel> ReadCsv(string filePath, string delimiter)
        {   
            logger.LogInformation($"Reading csv from file {filePath}");
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = delimiter
            };
            List<TRowModel> csvRows = new();
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Context.RegisterClassMap<TClassMap>();
                var records = csv.GetRecords<TRowModel>();
                csvRows.AddRange(records);
            }
            return csvRows;
        }
    }
}