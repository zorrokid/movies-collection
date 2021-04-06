using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Application.Models;
using Application.UseCases.ImportCsv;
using CsvHelper;
using CsvHelper.Configuration;

namespace Application.UseCases.ReadCsv
{
    public interface IReadCsvUseCase
    {
        IEnumerable<CsvRow> ReadCsv(String filePath/*, List<ImportTypeEnum> importers*/);
    }

    public class ReadCsvUseCase : IReadCsvUseCase
    {
        //private readonly DBImporterFactory factory;
        private readonly IDBImporter dbImporter;

        public ReadCsvUseCase(IDBImporter dbImporter /*DBImporterFactory factory*/)
        {
            this.dbImporter = dbImporter;
            // this.factory = factory;
        }

        public IEnumerable<CsvRow> ReadCsv(String filePath)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ","
            };
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Context.RegisterClassMap<CsvRowMap>();
                var records = csv.GetRecords<CsvRow>();
                foreach (var record in records)
                {
                    dbImporter.Import(record);
                    // foreach (var importType in importers)
                    // {
                        // var importer = factory.GetImporter(importType);
                        // importer.Import(record);
                        
                    //}
                    Console.WriteLine(record.OriginalTitle);
                }
                return records;
            }
        }
    }
}