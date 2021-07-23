
using System.Reflection;
using Auth.JWT;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configure
{
    public static class ConfigureApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {   
            services.AddSingleton<ITokenGenerator, JwtTokenGenerator>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}