using System;
using Microsoft.Extensions.DependencyInjection;
using Application.UseCases.ImportCsv;
using Application.Interfaces;
using Infrastructure.Persistance;
using Domain.Entities;

namespace CsvImport
{

    class Program
    {
        private static IServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            if (args.Length == 0) 
            {
                Console.WriteLine("Path to CSV-file must be provided");
                return;
            }
            string filePath = args[0];
            RegisterServices();
            IServiceScope scope = _serviceProvider.CreateScope();
            scope.ServiceProvider.GetRequiredService<ICsvImportClient>().Import(filePath);
            DisposeServices();
        }

        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IRepository<Movie>, MoviesRepository<Movie>>();
            services.AddSingleton<IImportCsvUseCase, ImportCsvUseCase>();   
            services.AddSingleton<ICsvImportClient, CsvImportClient>();            
            _serviceProvider = services.BuildServiceProvider(true);
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
    }
}
