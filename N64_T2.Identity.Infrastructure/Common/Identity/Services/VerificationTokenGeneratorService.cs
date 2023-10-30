using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;
using N64_T2.Identity.Application.Common.Enums;
using N64_T2.Identity.Application.Common.Identity.Models;
using N64_T2.Identity.Application.Common.Identity.Services;
using N64_T2.Identity.Application.Common.Settings;
using Newtonsoft.Json;

namespace N64_T2.Identity.Infrastructure.Common.Identity.Services;

public class VerificationTokenGeneratorService : IVerificationTokenGeneratorService
{
    private readonly IDataProtector _protector;
    private readonly VerificationTokenSettings _verificationTokenSettings;
    public VerificationTokenGeneratorService
        (
        IOptions<VerificationTokenSettings> options,
        IDataProtectionProvider provider
        )
    {
        _verificationTokenSettings = options.Value;
        _protector = provider.CreateProtector(_verificationTokenSettings.IdentityVerificationTokenPurpose);
    }
    public string GenerateToken(VerificationType verificationType, Guid userId)
    {
        var verificationToken = new VerificationToken
        {
            UserId = userId,
            Type = verificationType,
            ExpiryTime = DateTimeOffset.UtcNow.AddMinutes(_verificationTokenSettings.IdentityVerificationExpirationDurationInMinutes)
        };

        return _protector.Protect(JsonConvert.SerializeObject(verificationToken));
    }

    public (VerificationToken VerificationToken, bool IsValid) DecodeToken(string token)
    {
       if(string.IsNullOrWhiteSpace(token))
            throw new ArgumentNullException(nameof(token));

        var unprotectedToken = _protector.Unprotect(token);
        var verificationToken = JsonConvert.DeserializeObject<VerificationToken>(unprotectedToken) ??
            throw new ArgumentException("Invalid verification model", nameof(token));

        return (verificationToken, verificationToken.ExpiryTime > DateTimeOffset.UtcNow);
    }
}
