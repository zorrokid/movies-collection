using Application.Interfaces;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ConfigureInfrastructureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(MoviesRepository<>));
            services.AddDbContext<MoviesContext>(options => options.UseSqlite("Data Source=movies.db"));
            return services;
        }
    }
}