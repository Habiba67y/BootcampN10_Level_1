using N64_T2.Identity.Application.Common.Enums;
using N64_T2.Identity.Application.Common.Identity.Services;
using N64_T2.Identity.Application.Common.Notifications.Servcies;
using N64_T2.Identity.DoMain.Entities;

namespace N64_T2.Identity.Infrastructure.Common.Identity.Services;

public class AccountService : IAccountService
{
    private readonly IVerificationTokenGeneratorService _verificationTokenGeneratorService;
    private readonly IEmailOrchestrationService _emailOrchestrationService;
    private readonly IUserService _userService;

    public List<User> Users => _userService.Get(user => true).ToList();

    public AccountService
        (
        IVerificationTokenGeneratorService verificationTokenGeneratorService,
        IEmailOrchestrationService emailOrchestrationService,
        IUserService userService
        )
    {
        _emailOrchestrationService = emailOrchestrationService;
        _verificationTokenGeneratorService = verificationTokenGeneratorService;
        _userService = userService;
    }
    public ValueTask<bool> VerficateAsync(string token)
    {
        if(string.IsNullOrWhiteSpace(token))
            throw new ArgumentNullException(nameof(token));

        var verificationToken = _verificationTokenGeneratorService.DecodeToken(token);

        if(!verificationToken.IsValid)
            throw new InvalidOperationException("Invalid verification token");

        var result = verificationToken.VerificationToken.Type switch
        {
            VerificationType.EmailAddressVerification => MarkAsEmailVerifiedAync(verificationToken.VerificationToken.UserId),
            _ => throw new InvalidOperationException("This method is not intended to accept other types of tokens")
        };

        return result;
    }

    public ValueTask<User> CreateAsync(User user)
    {
        _userService.CreateAsync(user);

        var emailVerificationToken = _verificationTokenGeneratorService.GenerateToken(VerificationType.EmailAddressVerification, user.Id);
        _emailOrchestrationService.SendAsync(user.EmailAddress, emailVerificationToken);

        return new(user);
    }

    public async ValueTask<bool> MarkAsEmailVerifiedAync(Guid userId)
    {
        var foundUser = await _userService.GetByIdAsync(userId); 

        foundUser.IsEmailAddressVerified = true;

        return foundUser.IsEmailAddressVerified;
    }
}
