using N64_T2.Identity.Application.Common.Enums;
using N64_T2.Identity.Application.Common.Identity.Services;
using N64_T2.Identity.Application.Common.Notifications.Servcies;
using N64_T2.Identity.DoMain.Entities;

namespace N64_T2.Identity.Infrastructure.Common.Identity.Services;

public class AccountService : IAccountService
{
    public static readonly List<User> _users = new();
    public List<User> Users => _users;

    private readonly IVerificationTokenGeneratorService _verificationTokenGeneratorService;
    private readonly IEmailOrchestrationService _emailOrchestrationService;


    public AccountService
        (
        IVerificationTokenGeneratorService verificationTokenGeneratorService,
        IEmailOrchestrationService emailOrchestrationService
        )
    {
        _emailOrchestrationService = emailOrchestrationService;
        _verificationTokenGeneratorService = verificationTokenGeneratorService;
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
        _users.Add(user);

        var emailVerificationToken = _verificationTokenGeneratorService.GenerateToken(VerificationType.EmailAddressVerification, user.Id);
        _emailOrchestrationService.SendAsync(user.EmailAddress, emailVerificationToken);

        return new(user);
    }

    public ValueTask<bool> MarkAsEmailVerifiedAync(Guid userId)
    {
        var foundUser = _users.FirstOrDefault(user => user.Id == userId) ?? throw new InvalidOperationException("User not found");

        foundUser.IsEmailAddressVerified = true;

        return new(foundUser.IsEmailAddressVerified);
    }
}
