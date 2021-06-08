using Auth.JWT;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Configuration
{
    public static class AuthExtensions
    {
        public static IServiceCollection AddAuthServices(this IServiceCollection services)
        {
            services.AddSingleton<ITokenValidator, JwtTokenValidator>();
            return services;
        }
    }
}