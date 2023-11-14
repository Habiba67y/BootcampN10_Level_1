using N64_T2.Identity.Application.Common.Identity.Models;

namespace N64_T2.Identity.Application.Common.Identity.Services;

public interface IAuthService
{
    ValueTask<bool> Register(RegisterDetails registerDetails, CancellationToken cancellation = default);
    ValueTask<string> Login(LoginDetails loginDetails, CancellationToken cancellation = default);
    ValueTask<bool> GrandRoleAsync(Guid userId, string roleType, Guid actionUserId, CancellationToken cancellation = default);
}
