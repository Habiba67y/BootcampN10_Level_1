using N53_HT1.Api.Models;
using System.Linq.Expressions;

namespace N53_HT1.Api.Services.Interfaces;

public interface IOrderService
{
    IQueryable<Order> Get(Expression<Func<Order, bool>> predicate);

    ValueTask<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    ValueTask<Order> CreateAsync(Order order, bool saveChanges = true, CancellationToken cancellationToken = default);
}
