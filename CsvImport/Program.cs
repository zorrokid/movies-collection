using System;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Configure;
using Infrastructure.Integration.CSV.Configuration;
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
                    InitAndRun(o);
                });
        }

        private static void InitAndRun(Options options)
        { 
            using var loggerFactory = LoggerFactory.Create(builder => {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("CsvImport.Program", LogLevel.Debug)
                    .AddConsole();
            });
            var logger = loggerFactory.CreateLogger<Program>();

            RegisterServices(logger, options.ConfigPath);
            IServiceScope scope = serviceProvider.CreateScope();
            scope.ServiceProvider.GetRequiredService<ICsvImportClient>().Import(options.CsvFilePath);
            DisposeServices();

        }

        private static void RegisterServices(ILogger logger, string configPath)
        {
            var services = new ServiceCollection()
                .AddScoped<ICsvImportClient, CsvImportClient>()
                .AddSingleton<ILogger>(logger)
                .AddLogging(config => config.AddConsole())
                .AddApplicationServices()
                .AddInfrastructureServices(configPath)
                .AddIntegrationServices()
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
