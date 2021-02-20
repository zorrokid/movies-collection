using System;
using Application.UseCases.ImportCsv;
using Infrastructure.Persistance;
using Domain.Entities;

namespace CsvImport
{
    class Program
    {
        static void Main(string[] args)
        {
            var importClient = new CsvImportClient(new ImportCsvUseCase(new MoviesRepository<Movie>(new MoviesContext())));
            importClient.Import();
            Console.WriteLine("Hello World!");
        }
    }
}
