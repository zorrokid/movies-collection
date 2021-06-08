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
        private readonly ITokenValidator tokenValidator;


        public AuthorizationMiddleware(RequestDelegate next, 
            ITokenValidator tokenValidator)
        {
            this.tokenValidator = tokenValidator;

            this.next = next;
        }

        public async Task Invoke(HttpContext context, IIdentityRepository identityRepository)
        {
            var token = context.Request.Headers["Authorization"]
                .FirstOrDefault()?
                .Split()
                .Last();

            var userId = tokenValidator.ValidateToken(token);

            if (userId != null)
            {
                context.Items["User"] = await identityRepository.GetByIdAsync(userId.Value);
            }
            await next(context);
        }
    }
}