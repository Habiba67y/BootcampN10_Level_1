using N53_HT1.Api.Models;
using System.Reflection.Metadata.Ecma335;

namespace N53_HT1.Api.Events;

public class BonusEventStore
{
    public event Func<Bonus, ValueTask>? BonusAchievedEvent;

    public async ValueTask AchievedBonusUpdatedasync(Bonus bonus)
    {
        if (bonus != null)
            await BonusAchievedEvent(bonus);
    }
}
