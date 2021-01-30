using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Auth.API.Services.AuthTokenIssuer
{
    public class AuthTokenIssuer : IAuthTokenIssuer
    {
        private readonly IConfiguration _config;

        public AuthTokenIssuer(IConfiguration config)
        {
            _config = config;
        }

        public string GetAccessToken(Claim[] claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Auth:Secret"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _config["Auth:Issuer"],
                Audience = _config["Auth:Audience"],
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(_config.GetValue<int>("Auth:AccessTokenExpireHours", defaultValue: 2))
            };

            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);
        }
    }
}