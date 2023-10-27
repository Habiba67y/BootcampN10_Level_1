using N64_T2.Identity.Application.Common.Identity.Models;

namespace N64_T2.Identity.Application.Common.Identity.Services;

public interface IAuthService
{
    ValueTask<bool> Register(RegisterDetails registerDetails);
    ValueTask<string> Login(LoginDetails loginDetails);
}
