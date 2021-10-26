using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Extensions;
using Passenger.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Passenger.Infrastructure.Services
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JwtSettings _settings;

        public JwtHandler(JwtSettings settings)
        {
            _settings = settings;
        }

        public JwtDto CreateToken(string email, string role)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var now = DateTime.UtcNow;
            var expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_settings.ExpireMinutes));
            var expires1 = now.AddMinutes(_settings.ExpireMinutes);
            
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),

                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToTimestamp().ToString(), ClaimValueTypes.Integer64)
                //new Claim(JwtRegisteredClaimNames.Iat, now.ToTimestamp().ToString())
            };

            var token = new JwtSecurityToken(
            _settings.Issuer,
            _settings.Issuer,
            claims,
            notBefore: now,
            expires: expires,
            signingCredentials: creds
            );

            return new JwtDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expires = expires.ToTimestamp(),
            };
            
        }
    }
}
