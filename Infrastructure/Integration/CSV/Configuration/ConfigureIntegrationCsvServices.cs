using Infrastructure.Integration.CSV.Importers;
using Infrastructure.Integration.CSV.Models;
using Infrastructure.Integration.CSV.Readers;
using Infrastructure.Integration.CSV.RowMaps;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Integration.CSV.Configuration
{
    public static class ConfigureIntegrationCsvServices
    {
        public static IServiceCollection AddIntegrationCsvServices(this IServiceCollection services)
        {
            services
                .AddScoped<ICsvReader<CsvRow>, CsvReader<PublicationItemCsvRowMap, CsvRow>>()
                .AddScoped<ICsvImporter, CsvImporter>();
                
            return services;
        }
 
    }
}