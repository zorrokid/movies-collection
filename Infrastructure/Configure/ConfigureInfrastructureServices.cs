using System;
using Application.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configure
{
    public static class ConfigureInfrastructureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddTransient(typeof(INamedEntityRepository<>), typeof(NamedEntityRepository<>));
            services.AddTransient<IPublicationRepository, PublicationRepository>();

            IConfiguration config = ConfigurationProvider.GetConfiguration();

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