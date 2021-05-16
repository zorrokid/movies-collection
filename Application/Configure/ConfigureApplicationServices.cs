
using System.Reflection;
using Application.UseCases.ImportCsv;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configure
{
    public static class ConfigureApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {   
            services.AddScoped<IImportPublicationsUseCase, ImportPublicationsUseCase>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}