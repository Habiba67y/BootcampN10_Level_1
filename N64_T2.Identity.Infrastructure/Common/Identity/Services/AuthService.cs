using N64_T2.Identity.Application.Common.Identity.Models;
using N64_T2.Identity.Application.Common.Identity.Services;
using N64_T2.Identity.Application.Common.Notifications.Servcies;
using N64_T2.Identity.DoMain.Entities;
using N64_T2.Identity.DoMain.Enums;
using System.Security.Authentication;

namespace N64_T2.Identity.Infrastructure.Common.Identity.Services;

public class AuthService : IAuthService
{
    private readonly ITokenGeneratorService _tokenGenerateService;
    private readonly IPasswordHasherService _passwordHasherService;
    private readonly IAccountService _accountService;
    private readonly IEmailOrchestrationService _emailOrchestrationService;
    private readonly IAccessTokenService _tokenService;
    private readonly IUserService _userService;
    private readonly IRoleService _roleService;

    public AuthService
        (
        ITokenGeneratorService token, 
        IPasswordHasherService passwordHasherService,
        IAccountService accountService,
        IEmailOrchestrationService emailOrchestrationService,
        IAccessTokenService tokenService,
        IUserService userService,
        IRoleService roleService
        )
    {
        _tokenGenerateService = token;
        _passwordHasherService = passwordHasherService;
        _accountService = accountService;
        _emailOrchestrationService= emailOrchestrationService;
        _tokenService = tokenService;
        _userService = userService;
        _roleService = roleService;

    }
    public async ValueTask<bool> Register(RegisterDetails registerDetails, CancellationToken cancellation = default)
    {
        var foundUser = await _userService.GetByEmailAsync(registerDetails.EmailAddress, true, cancellation);
        if (foundUser is not null)
            throw new InvalidOperationException("User with this email address already exists.");

        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = registerDetails.FirstName,
            LastName = registerDetails.LastName,
            Age = registerDetails.Age,
            EmailAddress = registerDetails.EmailAddress,
            PasswordHash = _passwordHasherService.HashPassword(registerDetails.Password),
        };
        
        await _accountService.CreateAsync(user);
        var verificationEmailResult = await _emailOrchestrationService.SendAsync(user.EmailAddress, "Sistemaga xush kelibsiz!");

        return verificationEmailResult;
    }
    public async ValueTask<string> Login(LoginDetails loginDetails, CancellationToken cancellation = default)
    {
        var foundUser = await _userService.GetByEmailAsync(loginDetails.EmailAddress, true, cancellation) ?? throw new AuthenticationException("Email is invalid");
        
        if (!_passwordHasherService.ValidatePassword(loginDetails.Password, foundUser.PasswordHash))
        {
            throw new AuthenticationException("Password is invalid");
        }

        var token = _tokenGenerateService.GetToken(foundUser);
        await _tokenService.CreateAsync(foundUser.Id, token);

        return new(token);
    }

    public async ValueTask<bool> GrandRoleAsync
        (
        Guid userId, 
        string roleType, 
        Guid actionUserId, 
        CancellationToken cancellationToken = default
        )
    {
        var user = await _userService.GetByIdAsync(userId, cancellationToken: cancellationToken) ?? throw new InvalidOperationException();
        _ = await _userService.GetByIdAsync(actionUserId, cancellationToken: cancellationToken) ?? throw new InvalidOperationException();

        if (!Enum.TryParse(roleType, out RoleType roleValue)) throw new InvalidOperationException();
        var role = await _roleService.GetByTypeAsync(roleValue, cancellationToken: cancellationToken) ?? throw new InvalidOperationException();

        user.RoleId = role.Id;

        await _userService.UpdateAsync(user, cancellationToken: cancellationToken);

        return true;
    }
}
