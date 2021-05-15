using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Configure
{
    public static class ConfigurationProvider
    {
        public static IConfiguration GetConfiguration(string configPath)
        {
            var environment = GetEnvironment();

            var basePath = configPath ?? Directory.GetCurrentDirectory();

            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
            return config;
        }

        public static string GetEnvironment()
        {
            return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        }
    }
}