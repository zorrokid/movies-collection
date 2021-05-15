using System;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Configure;
using Infrastructure.Integration.CSV.Configuration;
using Infrastructure.Integration.CSV.Enums;
using Microsoft.Extensions.Logging;
using Application.Configure;
using CommandLine;

namespace CsvImport
{
    internal class Program
    {
        private static IServiceProvider serviceProvider;

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(o => 
                {
                    Console.WriteLine($"Import mode: {o.ImportMode}");
                    InitAndRun(o);
                });
        }

        private static void InitAndRun(Options options)
        { 
            var importMode = options.ImportMode;

            using var loggerFactory = LoggerFactory.Create(builder => {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("CsvImport.Program", LogLevel.Debug)
                    .AddConsole();
            });
            var logger = loggerFactory.CreateLogger<Program>();

            logger.LogInformation($"Import mode is {importMode}");

            RegisterServices(importMode, logger, options.ConfigPath);
            IServiceScope scope = serviceProvider.CreateScope();
            scope.ServiceProvider.GetRequiredService<ICsvImportClient>().Import(options.CsvFilePath);
            DisposeServices();

        }

        private static void RegisterServices(ImportModeEnum importMode, ILogger logger, string configPath)
        {
            var services = new ServiceCollection()
                .AddScoped<ICsvImportClient, CsvImportClient>()
                .AddSingleton<ILogger>(logger)
                .AddLogging(config => config.AddConsole())
                .AddApplicationServices()
                .AddInfrastructureServices(configPath)
                .AddIntegrationCsvServices(importMode);

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
