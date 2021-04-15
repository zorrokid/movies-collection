using Application.Interfaces;
using Infrastructure.Persistance;
using Infrastructure.Persistance.Csv.Importers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ConfigureInfrastructureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(MoviesRepository<>));
            services.AddTransient<ICsvImporter, PublicationCsvImporter>();
            //services.AddDbContext<MoviesContext>(options => options.UseSqlite("Data Source=movies.db"));
            services.AddDbContext<MoviesContext>(options => options.UseNpgsql("Host=localhost;Database=moviesdb;Username=movies;Password=movies123"));
            return services;
        }
    }
}