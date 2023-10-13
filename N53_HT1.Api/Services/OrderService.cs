using N53_HT1.Api.Data;
using N53_HT1.Api.Events;
using N53_HT1.Api.Models;
using N53_HT1.Api.Services.Interfaces;
using System.Linq.Expressions;

namespace N53_HT1.Api.Services;

public class OrderService : IOrderService
{
    private readonly IDataContext _dataContext;
    private readonly OrderEventStore _orderEventStore;
    private readonly IBonusService _bonusService;

    public OrderService(IDataContext dataContext, OrderEventStore orderEventStore, IBonusService bonusService)
    {
        _dataContext = dataContext;
        _orderEventStore = orderEventStore;
        _bonusService = bonusService;
    }
    public async ValueTask<Order> CreateAsync(Order order, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        await _dataContext.Orders.AddAsync(order, cancellationToken);
        await _orderEventStore.CreatedOrderAddedAsync(order);

       if (saveChanges)
            await _dataContext.SaveChangesAsync();

        return order;
    }

    public IQueryable<Order> Get(Expression<Func<Order, bool>> predicate) =>
        _dataContext.Orders.Where(predicate.Compile()).AsQueryable();

    public async ValueTask<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        await _dataContext.Orders.FindAsync(id, cancellationToken);
}
