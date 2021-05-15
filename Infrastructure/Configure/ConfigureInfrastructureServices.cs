using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configure
{
    public static class ConfigureInfrastructureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string configPath = null)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            IConfiguration config = ConfigurationProvider.GetConfiguration(configPath);

            var connectionString = config.GetConnectionString(nameof(MoviesContext));
            if (connectionString == null)
            {
                throw new Exception($"No connectionString {nameof(MoviesContext)} from config");
            }

            services.AddDbContext<MoviesContext>(options => options.UseNpgsql(connectionString));
            return services;
        }
    }
}