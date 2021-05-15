using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using Infrastructure.Integration.CSV.Importers;
using Infrastructure.Integration.CSV.Models;

namespace Infrastructure.Integration.CSV.Readers
{
    public class CsvReader<TClassMap, TRowModel> : ICsvReader
        where TClassMap : ClassMap<CsvRow>
    {
        private readonly ICsvImporter<TRowModel> csvImporter;

        public CsvReader(ICsvImporter<TRowModel> csvImporter)
        {
            this.csvImporter = csvImporter;
        }

        public void ReadCsv(string filePath, string delimiter)
        {   
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
                   csvImporter.Import(record);
                }            
            }
        }
    }
}