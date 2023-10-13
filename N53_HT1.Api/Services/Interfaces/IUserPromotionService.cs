using N53_HT1.Api.Models;

namespace N53_HT1.Api.Services.Interfaces;

public interface IUserPromotionService 
{
    ValueTask HandleAchievedBonusUpdatedasync(Bonus bonus);
}
