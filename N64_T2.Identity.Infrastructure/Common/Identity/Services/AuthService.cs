using N64_T2.Identity.Application.Common.Identity.Models;
using N64_T2.Identity.Application.Common.Identity.Services;
using N64_T2.Identity.DoMain.Entities;
using System.Security.Authentication;

namespace N64_T2.Identity.Infrastructure.Common.Identity.Services;

public class AuthService : IAuthService
{
    private static readonly List<User> _users = new();
    private readonly ITokenGenerateService _tokenGenerateService;
    private readonly IPasswordHasherService _passwordHasherService;
    public AuthService(ITokenGenerateService token, IPasswordHasherService passwordHasherService)
    {
        _tokenGenerateService = token;
        _passwordHasherService = passwordHasherService;

    }
    public ValueTask<bool> Register(RegisterDetails registerDetails)
    {
        _users.Add(new User
        {
            Id = Guid.NewGuid(),
            FirstName = registerDetails.FirstName,
            LastName = registerDetails.LastName,
            EmailAddress = registerDetails.EmailAddress,
            Password = _passwordHasherService.HashPassword(registerDetails.Password),
        });

        return new(true);
    }
    public ValueTask<string> Login(LoginDetails loginDetails)
    {
        var foundUser = _users.FirstOrDefault(u => u.EmailAddress.Equals(loginDetails.EmailAddress)) ?? throw new AuthenticationException("User not found");

        return new(_tokenGenerateService.GetToken(foundUser));
    }
}
