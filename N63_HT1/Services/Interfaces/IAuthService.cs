using N63_HT1.Models.Dtos;

namespace N63_HT1.Services.Interfaces;

public interface IAuthService
{
    ValueTask<bool> Register(RegisterDetails registerDetails);
    ValueTask<string> Login(LoginDetails loginDetails);
}
