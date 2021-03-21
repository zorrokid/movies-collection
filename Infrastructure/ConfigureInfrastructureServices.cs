using Application.Interfaces;
using Infrastructure.Persistance;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ConfigureInfrastructureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(MoviesRepository<>));
            return services;
        }
    }
}