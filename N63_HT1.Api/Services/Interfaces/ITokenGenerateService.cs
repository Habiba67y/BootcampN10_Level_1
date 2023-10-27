using N63_HT1.Api.Entities;

namespace N63_HT1.Api.Services.Interfaces;

public interface ITokenGenerateService
{
    string GetToken(User user);
}
