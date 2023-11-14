using N64_T2.Identity.DoMain.Entities;

namespace N64_T2.Identity.Application.Common.Identity.Services;

public interface IAccountService
{
    ValueTask<bool> VerficateAsync(string token);
    ValueTask<User> CreateAsync(User user);
}
