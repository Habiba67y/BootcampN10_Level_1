using N53_HT1.Api.Events;
using N53_HT1.Api.Models;
using N53_HT1.Api.Services.Interfaces;

namespace N53_HT1.Api.Services;

public class UserPromotionService : IUserPromotionService
{
    private readonly IEnumerable<INotificationService> _notificationServices;
    private readonly BonusEventStore _bonusEventStore;
    public UserPromotionService(IEnumerable<INotificationService> notificationServices, BonusEventStore bonusEventStore)
    {
        _notificationServices = notificationServices;
        _bonusEventStore = bonusEventStore;

        _bonusEventStore.BonusAchievedEvent += HandleAchievedBonusUpdatedasync;
    }
    public async ValueTask HandleAchievedBonusUpdatedasync(Bonus bonus)
    {
        Console.WriteLine("Notifying user");
        var content = "You achieved next bonus";
        Task.WhenAll(_notificationServices
                        .Select(notificationService => notificationService
                        .SendAsync(bonus.UserId, content).AsTask()));
    }
}
