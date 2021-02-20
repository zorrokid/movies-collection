using System;
using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCases.ImportCsv
{
    public interface IImportCsvUseCase
    {
        void ImportCsv();
    }

    public class ImportCsvUseCase : IImportCsvUseCase
    {
        private readonly IRepository<Movie> repository;

        public ImportCsvUseCase(IRepository<Movie> repository)
        {
            this.repository = repository;
        }

        public void ImportCsv()
        {
            Console.Out.WriteLine("Start import");
        }
    }
}