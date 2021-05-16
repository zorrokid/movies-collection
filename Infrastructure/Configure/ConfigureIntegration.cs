using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Integration;

namespace Infrastructure.Configure
{
    public static class ConfigureIntegrationServices
    {
        public static IServiceCollection AddIntegrationServices(this IServiceCollection services) 
            => services.AddScoped<IIntegration, IntegrationService>();

    }
}