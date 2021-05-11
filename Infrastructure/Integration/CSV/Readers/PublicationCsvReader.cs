using System;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using Infrastructure.Integration.CSV.Importers;
using Infrastructure.Integration.CSV.Models;
using Infrastructure.Integration.CSV.RowMaps;

namespace Infrastructure.Integration.CSV.Readers
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