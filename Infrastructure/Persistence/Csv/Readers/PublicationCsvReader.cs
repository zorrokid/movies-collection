using System;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using Infrastructure.Persistence.Csv.Importers;
using Infrastructure.Persistence.Csv.Models;
using Infrastructure.Persistence.Csv.RowMaps;

namespace Infrastructure.Persistence.Csv.Readers
{
    public class PublicationCsvReader : ICsvReader
    {
        private readonly ICsvImporter csvImporter;

        public PublicationCsvReader(ICsvImporter csvImporter)
        {
            this.csvImporter = csvImporter;
        }

        public void ReadCsv(string filePath)
        {   
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ","
            };
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Context.RegisterClassMap<PublicationCsvRowMap>();
                var records = csv.GetRecords<CsvRow>();
                foreach (var record in records)
                {
                    Console.WriteLine(record.OriginalTitle);
                    csvImporter.Import(record);
                }            
            }
        }
    }
}