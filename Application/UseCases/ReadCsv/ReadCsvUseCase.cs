using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Application.Interfaces;
using Application.Models;
using CsvHelper;
using CsvHelper.Configuration;
using Domain.Entities;

namespace Application.UseCases.ReadCsv
{
    public interface IReadCsvUseCase
    {
        IEnumerable<CsvRow> ReadCsv(String filePath);
    }

    public class ReadCsvUseCase : IReadCsvUseCase
    {
        private readonly IRepository<Movie> repository;

        public ReadCsvUseCase(IRepository<Movie> repository)
        {
            this.repository = repository;
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
                return csv.GetRecords<CsvRow>();
            }
        }
    }
}