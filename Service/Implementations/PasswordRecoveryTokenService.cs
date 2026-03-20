using Dealership.Model.Entities;
using Dealership.Service.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace Dealership.Service.Implementations;

public class PasswordRecoveryTokenService : IPasswordRecoveryTokenService
{
    private readonly IConfiguration _configuration;

    public PasswordRecoveryTokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public bool ValidateRecoveryToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:SecretKey"]!);
        var jwtSettings = _configuration.GetSection("JwtSettings");

        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidIssuer = jwtSettings["Issuer"],
                ValidateAudience = true,
                ValidAudience = jwtSettings["Audience"],
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwt = (JwtSecurityToken)validatedToken;
            var tokenType = jwt.Claims.FirstOrDefault(c => c.Type == "token_type")?.Value;

            if (tokenType != "password_recovery")
                return false;

            return true;
        }
        catch
        {
            return false;
        }
    }

    public string GenerateRecoveryToken (AdminUsers admin)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:SecretKey"]);

        var jwtSettings = _configuration.GetSection("JwtSettings");

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString()),
                new Claim("token_type", "password_recovery")
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