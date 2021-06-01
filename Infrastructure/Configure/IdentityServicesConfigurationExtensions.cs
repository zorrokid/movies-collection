using System;
using Auth.Interfaces;
using Infrastructure.Persistence.Database;
using Infrastructure.Persistence.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configure
{
    public static class IdentityServicesConfigurationExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, string configPath = null)
        {
            IConfiguration config = ConfigurationProvider.GetConfiguration(configPath);

            var connectionString = config.GetConnectionString(nameof(IdentityContext));
            if (connectionString == null)
            {
                throw new Exception($"No connectionString {nameof(IdentityContext)} from config");
            }

            services.AddDbContext<IdentityContext>(options => options.UseNpgsql(connectionString));
            services.AddTransient<IIdentityRepository, IdentityRepository>();

            return services;
        }
        
    }
}