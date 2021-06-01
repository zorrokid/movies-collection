using System;
using Application.Interfaces;
using Infrastructure.Persistence.Database;
using Infrastructure.Persistence.Database.Repositories;
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
            services.AddTransient<IPublicationAsyncRepository, PublicationAsyncRepository>();

            IConfiguration config = ConfigurationProvider.GetConfiguration(configPath);

            var connectionString = config.GetConnectionString(nameof(ApplicationContext));
            if (connectionString == null)
            {
                throw new Exception($"No connectionString {nameof(ApplicationContext)} from config");
            }

            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connectionString));
            return services;
        }
    }
}