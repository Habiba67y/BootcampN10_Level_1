using N64_T2.Identity.Application.Common.Enums;
using N64_T2.Identity.Application.Common.Identity.Models;

namespace N64_T2.Identity.Application.Common.Identity.Services;

public interface IVerificationTokenGeneratorService
{
    string GenerateToken(VerificationType verificationType, Guid UserId);
    (VerificationToken VerificationToken, bool IsValid) DecodeToken(string token);
}
