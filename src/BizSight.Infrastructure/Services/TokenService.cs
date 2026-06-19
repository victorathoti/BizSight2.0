using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BizSight.Application.DTOs.Authentication;
using BizSight.Application.Interfaces.Services;
using BizSight.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BizSight.Infrastructure.Services;

public class TokenService : ITokenService
{
    private readonly JwtSettingsDTO _jwtSettings;

    public TokenService(IOptions<JwtSettingsDTO> jwtOptions)
    {
        _jwtSettings = jwtOptions.Value;
    }

    public string GenerateAccessToken(
        ApplicationUser user,
        string companyName,
        string roleName)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new(ClaimTypes.Name, user.UserName),
            new(ClaimTypes.Role, roleName),

            new("CompanyName", companyName),
            new("UserId", user.Id.ToString())
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));

        var credentials = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(
                _jwtSettings.ExpiryMinutes),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler()
            .WriteToken(token);
    }
}