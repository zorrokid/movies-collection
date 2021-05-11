using Infrastructure.Integration.CSV.Importers;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Integration.CSV.Configuration
{
    public static class ConfigureIntegrationCsvServices
    {
        public static IServiceCollection AddIntegrationCsvServices(this IServiceCollection services)
        {
            services.AddScoped<ICsvImporter, PublicationCsvImporter>();
            return services;
        }
 
    }
}