using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using N63_HT1.Constants;
using N63_HT1.Models.Entities;
using N63_HT1.Models.Settings;
using N63_HT1.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace N63_HT1.Services;

public class TokenGenerateService : ITokenGenerateService
{
    private readonly JwtSettings _jwtSettings;

    public TokenGenerateService(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }
    public string GetToken(User user)
    {
        var jwtToken = GetJwtToken(user);
        var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        return token;
    }
    public JwtSecurityToken GetJwtToken(User user)
    {
        var claims = GetClaims(user);
        var secureKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        var credentials = new SigningCredentials(secureKey, SecurityAlgorithms.HmacSha256);

        return new JwtSecurityToken
            (
            issuer: _jwtSettings.ValidIssuer,
            audience: _jwtSettings.ValidAudience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationInMinutes),
            signingCredentials: credentials
            );
    }
    public List<Claim> GetClaims(User user)
    {
        return new List<Claim>
        {
            new(ClaimTypes.Email, user.EmailAddress),
            new(ClaimConstant.UserId, user.Id.ToString())
        };
    }
}
