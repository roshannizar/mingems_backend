using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Mingems.Core.Models;
using Mingems.Core.Services;
using Mingems.Shared.Core.Helpers;
using Mingems.Shared.Infrastructure.Exceptions;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Mingems.Infrastructure.Services
{
    public class UtilityService : IUtilityService
    {
        private readonly AppSettings _appsettings;

        public UtilityService(IOptions<AppSettings> appsettings)
        {
            _appsettings = appsettings.Value;
        }

        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appsettings.Secret);
            var date = DateTime.Now.AddHours(24);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                    new Claim(ClaimTypes.Email,user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),
                    new Claim(ClaimTypes.Expired, date.Ticks.ToString())
                }),
                Expires = date,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string ValidateToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var validatedToken = handler.ReadJwtToken(token);

            var email = validatedToken.Claims.FirstOrDefault(c => c.Type == "email").Value;
            var expires = validatedToken.Claims.
                FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/expired").Value;
            DateTime expireDate = new DateTime(long.Parse(expires));
            int result = DateTime.Compare(DateTime.Now, expireDate);
            if (result > -1)
                throw new SecurityTokenExpiredException("Token expired");

            if (email == null)
                throw new ExpiredTokenException("Invalid Token, token may have been expired or invalid");
            else
                return email;
        }
    }
}
