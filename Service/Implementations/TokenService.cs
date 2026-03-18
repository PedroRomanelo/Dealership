using Dealership.Model.Entities;
using Dealership.Service.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace Dealership.Service.Implementations;

public class TokenService: ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService (IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken (AdminUsers admin)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:SecretKey"]);

        var jwtSettings = _configuration.GetSection("JwtSettings");

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString()), //posteriormente caso nn tenha utilidade, retirar essa linha
                new Claim(ClaimTypes.Role, admin.Role.ToString().ToLower()),
                new Claim(ClaimTypes.Email, admin.Login)
            }),
            Audience = jwtSettings["Audience"],
            Issuer = jwtSettings["Issuer"],
            Expires = DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["ExpirationTimeInMinutes"])),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}