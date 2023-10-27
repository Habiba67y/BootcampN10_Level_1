using Microsoft.AspNetCore.Identity;
using N64_T2.Identity.Application.Common.Identity.Services;

namespace N64_T2.Identity.Infrastructure.Common.Identity.Services;

public class PasswordHasherService : IPasswordHasherService
{
    public string HashPassword(string password)
    => BCrypt.Net.BCrypt.HashPassword(password);

    public bool ValidatePassword(string password, string hash)
    => BCrypt.Net.BCrypt.Verify(password, hash);
}
