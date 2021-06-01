using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using Auth.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Auth.JWT
{
    public interface ITokenValidator
    {
        int? ValidateToken(string token);
    }

    public class JwtTokenValidator : ITokenValidator
    {
        private readonly AuthSettings authSettings;

        public JwtTokenValidator(IOptions<AuthSettings> authSettings)
        {
            this.authSettings = authSettings.Value;
        }
        
        public int? ValidateToken(string token)
        {
            if (token == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(authSettings.Secret);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                // return user id from JWT token if validation successful
                return userId;
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }
    }
}