using N48_HT1.Api.Models;
using N48_HT1.Api.Service.Interfaces;
using N48_HT1.Api.Services.Interfaces;

namespace N48_HT1.Api.Services;

public class UserOrders : IUserOrders
{
    private readonly IOrderService _orderService;
    public UserOrders(IOrderService orderService)
    {
        _orderService = orderService;
    }
    public IQueryable<Order> Get(Guid userId)
    {
        var orders = _orderService.Get(order => order.UserId == userId);
        return orders;
    }
}
