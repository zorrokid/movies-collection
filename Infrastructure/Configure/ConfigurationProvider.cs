using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Configure
{
    public static class ConfigurationProvider
    {
        public static IConfiguration GetConfiguration()
        {
            var environment = GetEnvironment();

            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
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