using N63_HT1.Models.Entities;

namespace N63_HT1.Services.Interfaces;

public interface ITokenGenerateService
{
    string GetToken(User user);
}
