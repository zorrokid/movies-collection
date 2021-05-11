using Application.Interfaces;
using Infrastructure.Integration.CSV.Enums;
using Infrastructure.Integration.CSV.Importers;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Integration.CSV.Configuration
{
    public static class ConfigureIntegrationCsvServices
    {
        public static IServiceCollection AddIntegrationCsvServices(this IServiceCollection services, ImportModeEnum importMode)
        {
                    
            services.AddScoped<ICsvImporter>((serviceProvider) => {
                var unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
            
                if (importMode == ImportModeEnum.PublicationItem)
                {
                    return new PublicationItemCsvImporter(unitOfWork);
                }
                return new PublicationCsvImporter(unitOfWork);
            } );
            
            return services;
        }
 
    }
}