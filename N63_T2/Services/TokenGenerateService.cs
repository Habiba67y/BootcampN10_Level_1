using Microsoft.IdentityModel.Tokens;
using N63_T2.Constants;
using N63_T2.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace N63_T2.Services;

public class TokenGenerateService
{
    public readonly string SecretKey = "27a70c3f-58e1-484b-a2e5-fd9ea80d8ec1";
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
