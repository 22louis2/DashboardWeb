using DashboardWeb.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DashboardWeb.Helpers
{
    public class Utility
    {
        private readonly IConfiguration _config;

        public Utility(IConfiguration config)
        {
            _config = config;
        }

        public string JWTHandler(UserModel user)
        {
            // 1. Create claims for JWT
            var claims = new[]
            {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.LastName)
                };

            // 2. Get JWT Secret Key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            // 3. Generate the Signing Credentials
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            // 4. Create Security Token Descriptor
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(30),
                SigningCredentials = creds
            };

            // 5. Build Token Handler
            var tokenHandler = new JwtSecurityTokenHandler();

            // 6. Create the token
            var token = tokenHandler.CreateToken(securityTokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
