using Microsoft.AspNetCore.Routing.Constraints;
using N53_HT1.Api.Events;
using N53_HT1.Api.Models;
using N53_HT1.Api.Services.Interfaces;

namespace N53_HT1.Api.Services;

public class UserBonusService : IUserBonusService
{
    private readonly OrderEventStore _orderEventStore;
    private readonly BonusEventStore _bonusEventStore;
    private readonly IEnumerable<INotificationService> _notificationServices;
    private readonly IBonusService _bonusService;
    public UserBonusService(
        OrderEventStore orderEventStore,
        BonusEventStore bonusEventStore,
        IEnumerable<INotificationService> notificationServices,
        IBonusService bonusService)
    {
        _orderEventStore = orderEventStore;
        _bonusEventStore = bonusEventStore;
        _notificationServices = notificationServices;
        _bonusService = bonusService;

        _orderEventStore.OrderCreatedEvent += HandleCreatedOrderAsync;
    }

    public async ValueTask HandleCreatedOrderAsync(Order order)
    {
        Console.WriteLine("Notifying user");

        var bonus = _bonusService.Get(b => b.UserId == order.UserId).FirstOrDefault();
        if (bonus is null)
        {
            await _bonusService.CreateAsync(new Bonus { Id = Guid.NewGuid(), UserId = order.UserId, Amount = order.Price });
            return;
        }

        var oldamount = bonus.Amount;
        var updatedBonus = new Bonus { Id = bonus.Id, UserId = bonus.UserId, Amount = bonus.Amount + order.Price };

        var achievment = ToAchieveBonus(oldamount, updatedBonus.Amount);
        if (achievment <= 0)
            await _bonusService.UpdateAsync(updatedBonus);
        else
        {
            var content = $"The need amount to achieve next bouns {achievment}";
            Task.WhenAll(_notificationServices
                .Select(notificationService => notificationService
                .SendAsync(order.UserId, content).AsTask()));
        }

    }

    private int ToAchieveBonus(int oldBonus, int newBonus)
    {
        var number = oldBonus;
        var lengthOfNumber = 0;
        while (number >= 1)
        {
            number /= 10;
            lengthOfNumber += 1;
        }

        var nextNumber = Math.Pow(10, lengthOfNumber);
        return (int)nextNumber - newBonus;
    }
}
