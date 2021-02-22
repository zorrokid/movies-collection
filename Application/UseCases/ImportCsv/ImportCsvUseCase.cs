using System;
using System.Globalization;
using System.IO;
using Application.Interfaces;
using CsvHelper;
using CsvHelper.Configuration;
using Domain.Entities;

namespace Application.UseCases.ImportCsv
{
    public interface IImportCsvUseCase
    {
        void ImportCsv(String filePath);
    }

    public class ImportCsvUseCase : IImportCsvUseCase
    {
        private readonly IRepository<Movie> repository;

        public ImportCsvUseCase(IRepository<Movie> repository)
        {
            this.repository = repository;
        }

        public void ImportCsv(String filePath)
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
                foreach(var rec in records)
                {
                    Console.WriteLine(rec.ToString());
                }
            }
        }
    }
}