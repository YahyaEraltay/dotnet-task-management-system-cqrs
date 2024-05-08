using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManagementSystem.Application.Users.Commands.Login;
using TaskManagementSystem.Infrastructure.DTOs.UserDTOs.LoginUserDTOs;

namespace TaskManagementSystem.Infrastructure.Services
{
    public class GenerateJwtToken : IGenerateJwtToken
    {
        private readonly IConfiguration _configuration;

        public GenerateJwtToken(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(LoginUserResponse response)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var securityKey = new SymmetricSecurityKey(key);
            if (securityKey.KeySize < 256)
            {
                var newKey = new byte[32];
                Array.Copy(key, newKey, Math.Min(key.Length, newKey.Length));
                securityKey = new SymmetricSecurityKey(newKey);
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, response.UserEmail)
                }),

                Expires = DateTime.UtcNow.AddHours(1),
                Audience = _configuration["Jwt:Audience"],
                Issuer = _configuration["Jwt:Issuer"],
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
