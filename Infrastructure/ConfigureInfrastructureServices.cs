using Application.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Csv.Importers;
using Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ConfigureInfrastructureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddTransient<ICsvImporter, PublicationCsvImporter>();
            //services.AddDbContext<MoviesContext>(options => options.UseSqlite("Data Source=movies.db"));
            services.AddDbContext<MoviesContext>(options => options.UseNpgsql("Host=localhost;Database=moviesdb;Username=movies;Password=movies123"));
            return services;
        }
    }
}