using Microsoft.IdentityModel.Tokens;
using N62_HT1.Api.Constants;
using N62_HT1.Api.Entities;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace N62_HT1.Api.Services;

public class TokenGeneratorService
{
    public string SecretKey = "27a70c3f-58e1-484b-a2e5-fd9ea80d8ec1";

    public string GetToken(User user)
    {
        var jwtToken = GetJwtToken(user);
        var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

        return token;
    }
    public JwtSecurityToken GetJwtToken(User user)
    {
        var claims = GetClaims(user);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

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
            new (ClaimTypes.Email, user.EmailAddress),
            new (ClaimConstants.UserId, user.Id.ToString())
        };
    }
}
