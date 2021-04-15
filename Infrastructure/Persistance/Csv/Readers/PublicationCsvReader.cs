using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using Infrastructure.Persistance.Csv.Importers;
using Infrastructure.Persistance.Csv.Models;
using Infrastructure.Persistance.Csv.RowMaps;

namespace Infrastructure.Persistance.Csv.Readers
{
    public class PublicationCsvReader : ICsvReader
    {
        private readonly ICsvImporter csvImporter;

        public PublicationCsvReader(ICsvImporter csvImporter)
        {
            this.csvImporter = csvImporter;
        }

        public IEnumerable<CsvRow> ReadCsv(string filePath)
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
                }
                return records;
            }
        }
    }
}