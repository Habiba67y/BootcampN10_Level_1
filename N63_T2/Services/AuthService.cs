using N63_T2.Dtos;
using N63_T2.Entities;
using System.Security.Authentication;

namespace N63_T2.Services;

public class AuthService
{
    private static readonly List<User> _users = new();
    private readonly TokenGenerateService _tokenGenerateService;
    public AuthService(TokenGenerateService token)
    {
        _tokenGenerateService = token;
    }
    public ValueTask<bool> Register(RegisterDetails registerDetails)
    {
        _users.Add(new User
        {
            Id = Guid.NewGuid(),
            FirstName = registerDetails.FirstName,
            LatsName = registerDetails.LastName,
            EmailAddress = registerDetails.EmailAddress,
            Password = registerDetails.Password,
        });

        return new(true);
    }
    public ValueTask<string> Login(LoginDetails loginDetails)
    {
        var foundUser = _users.FirstOrDefault(u => u.EmailAddress.Equals(loginDetails.EmailAddress)) ?? throw new AuthenticationException("User not found");

        return new(_tokenGenerateService.GetToken(foundUser));
    }
}
