
using Application.UseCases.ImportCsv;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ConfigureApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {   
            services.AddScoped<IImportPublicationsUseCase, ImportPublicationsUseCase>();
            return services;
        }
    }
}