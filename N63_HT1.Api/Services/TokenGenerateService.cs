using N63_HT1.Api.Entities;
using N63_HT1.Api.Services.Interfaces;
using System.Security.Claims;
using System.Text;

namespace N63_HT1.Api.Services;

public class TokenGenerateService : ITokenGenerateService
{
    public readonly string SecretKey = "";
    public string GetToken(User user)
    {
        var jwtToken = GetJwtToken(user);
        var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        return token;
    }
    public JwtSecurityToken GetJwtToken(User user)
    {
        var claims = GetClaims(user);
        var secureKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
        var credentials = new SigningCredentials(secureKey, SecurityAlgorithms.HmacSha256);

        return new JwtSecurityToken
            (
            issuer: "ServerApp",
            audience: "ClientApp",
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddDays(1),
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
