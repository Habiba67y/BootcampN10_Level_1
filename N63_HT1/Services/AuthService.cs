using N63_HT1.Models.Dtos;
using N63_HT1.Models.Entities;
using N63_HT1.Services.Interfaces;
using System.Security.Authentication;

namespace N63_HT1.Services;

public class AuthService : IAuthService
{
    private readonly IUserService _userService;
    private readonly ITokenGenerateService _tokenGenerateService;

    public AuthService
        (IUserService userService,
        ITokenGenerateService tokenGenerateService)
    {
        _userService = userService;
        _tokenGenerateService = tokenGenerateService;
    }

    public async ValueTask<bool> Register(RegisterDetails registerDetails)
    {
        var user = new User
        {
            FirstName = registerDetails.FirstName,
            LastName = registerDetails.LastName,
            EmailAddress = registerDetails.EmailAddress,
            Password = registerDetails.Password,
            Age = registerDetails.Age,
        };

        var createdUser = await _userService.CreateAsync(user);

        return createdUser != null;
    }

    public ValueTask<string> Login(LoginDetails loginDetails)
    {
        var foundUser = _userService.Get(user => user.EmailAddress.Equals(loginDetails.EmailAddress) && user.Password.Equals(loginDetails.Password)).FirstOrDefault() ?? throw new AuthenticationException("Login details are invalid");

        var token = _tokenGenerateService.GetToken(foundUser);

        return new(token);
    }
}   
