using System.Linq;
using System.Threading.Tasks;
using Auth.Interfaces;
using Auth.JWT;
using Microsoft.AspNetCore.Http;

namespace Auth.Middleware
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ITokenValidator jwtTokenValidator;
        private readonly IIdentityRepository identityRepository;

        public AuthorizationMiddleware(RequestDelegate next, 
            ITokenValidator jwtTokenValidator,
            IIdentityRepository identityRepository)
        {
            this.jwtTokenValidator = jwtTokenValidator;
            this.identityRepository = identityRepository;
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"]
                .FirstOrDefault()?
                .Split()
                .Last();

            var userId = jwtTokenValidator.ValidateToken(token);

            if (userId != null)
            {
                context.Items["User"] = await identityRepository.GetByIdAsync(userId.Value);
            }
        }
    }
}