using System.Linq.Expressions;
using N48_HT1.Api.Models;

namespace N48_HT1.Api.Services.Interfaces;

public interface IUserOrders
{
    IQueryable<Order> Get(Guid userId);
}
