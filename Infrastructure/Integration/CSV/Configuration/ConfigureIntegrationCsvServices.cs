using Application.Interfaces;
using Infrastructure.Integration.CSV.Enums;
using Infrastructure.Integration.CSV.Importers;
using Infrastructure.Integration.CSV.Models;
using Infrastructure.Integration.CSV.Readers;
using Infrastructure.Integration.CSV.RowMaps;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Integration.CSV.Configuration
{
    public static class ConfigureIntegrationCsvServices
    {
        public static IServiceCollection AddIntegrationCsvServices(this IServiceCollection services, ImportModeEnum importMode)
        {
            services
                .AddScoped<ICsvReader, CsvReader<PublicationItemCsvRowMap, CsvRow>>()        
                .AddScoped<ICsvImporter<CsvRow>>((serviceProvider) => {
                    var unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
                    if (importMode == ImportModeEnum.PublicationItem)
                    {
                        return new PublicationItemCsvImporter(unitOfWork, serviceProvider.GetRequiredService<ILogger<PublicationItemCsvImporter>>());
                    }
                     
                    return new PublicationCsvImporter(unitOfWork, serviceProvider.GetRequiredService<ILogger<PublicationCsvImporter>>());
                });
                
            return services;
        }
 
    }
}