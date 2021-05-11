using System;
using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces;
using Infrastructure.Integration;
using Infrastructure.Integration.CSV.Readers;
using Infrastructure.Configure;
using Application.Configure;
using Infrastructure.Integration.CSV.Configuration;

namespace CsvImport
{

    internal class Program
    {
        private static IServiceProvider serviceProvider;

        static void Main(string[] args)
        {
            if (args.Length == 0) 
            {
                Console.WriteLine("Path to CSV-file must be provided");
                return;
            }
            string filePath = args[0];
            RegisterServices();
            IServiceScope scope = serviceProvider.CreateScope();
            scope.ServiceProvider.GetRequiredService<ICsvImportClient>().Import(filePath);
            DisposeServices();
        }

        private static void RegisterServices()
        {
            var services = new ServiceCollection()
                .AddScoped<ICsvImportClient, CsvImportClient>()
                .AddScoped<IIntegration, Integration>()
                .AddScoped<ICsvReader, PublicationCsvReader>()
                .AddApplicationServices()
                .AddInfrastructureServices()
                .AddIntegrationCsvServices();

            serviceProvider = services.BuildServiceProvider(true);
        }

        private static void DisposeServices()
        {
            if (serviceProvider == null)
            {
                return;
            }
            if (serviceProvider is IDisposable)
            {
                ((IDisposable)serviceProvider).Dispose();
            }
        }
    }
}
