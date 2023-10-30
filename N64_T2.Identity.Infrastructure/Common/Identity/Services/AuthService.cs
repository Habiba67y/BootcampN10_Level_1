using N64_T2.Identity.Application.Common.Identity.Models;
using N64_T2.Identity.Application.Common.Identity.Services;
using N64_T2.Identity.Application.Common.Notifications.Servcies;
using N64_T2.Identity.DoMain.Entities;
using System.Security.Authentication;

namespace N64_T2.Identity.Infrastructure.Common.Identity.Services;

public class AuthService : IAuthService
{
    private readonly ITokenGeneratorService _tokenGenerateService;
    private readonly IPasswordHasherService _passwordHasherService;
    private readonly IAccountService _accountService;
    private readonly IEmailOrchestrationService _emailOrchestrationService;

    public AuthService
        (
        ITokenGeneratorService token, 
        IPasswordHasherService passwordHasherService,
        IAccountService accountService,
        IEmailOrchestrationService emailOrchestrationService
        )
    {
        _tokenGenerateService = token;
        _passwordHasherService = passwordHasherService;
        _accountService = accountService;
        _emailOrchestrationService= emailOrchestrationService;

    }
    public async ValueTask<bool> Register(RegisterDetails registerDetails)
    {
        var foundUser = _accountService.Users.FirstOrDefault(user => user.EmailAddress == registerDetails.EmailAddress);
        if (foundUser is not null)
            throw new InvalidOperationException("User with this email address already exists.");

        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = registerDetails.FirstName,
            LastName = registerDetails.LastName,
            Age = registerDetails.Age,
            EmailAddress = registerDetails.EmailAddress,
            Password = _passwordHasherService.HashPassword(registerDetails.Password),
        };
        
        await _accountService.CreateAsync(user);
        var verificationEmailResult = await _emailOrchestrationService.SendAsync(user.EmailAddress, "Sistemaga xush kelibsiz!");

        return verificationEmailResult;
    }
    public ValueTask<string> Login(LoginDetails loginDetails)
    {
        var foundUser = _accountService.Users.FirstOrDefault(u => u.EmailAddress.Equals(loginDetails.EmailAddress)) 
            ?? throw new AuthenticationException("Email is invalid");
        
        if (!_passwordHasherService.ValidatePassword(loginDetails.Password, foundUser.Password))
        {
            throw new AuthenticationException("Password is invalid");
        }

        return new(_tokenGenerateService.GetToken(foundUser));
    }
}
