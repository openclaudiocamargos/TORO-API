using Application.Commom.Interfaces;
using Domain.Entities;
using Infrastructure.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly ProjectSettings _settings;

        public UserAuthenticationService(IOptions<ProjectSettings> settings)
        {
            _settings = settings.Value;
        }

        public string GenerateJWT(string valueId)
        {

            var claims = new[] {
                        new Claim(ClaimTypes.Sid, valueId)
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.JWTSecretKey!));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _settings.JWTIssuer!,
                _settings.JWTAudience!,
                claims,
                expires: DateTime.UtcNow.AddHours(6),
                signingCredentials: signIn);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
