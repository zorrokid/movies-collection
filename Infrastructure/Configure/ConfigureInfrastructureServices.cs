using System;
using System.IO;
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
            //services.AddDbContext<MoviesContext>(options => options.UseSqlite("Data Source=movies.db"));

            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

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