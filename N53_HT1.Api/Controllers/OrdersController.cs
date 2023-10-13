using Microsoft.AspNetCore.Mvc;
using N53_HT1.Api.Models;
using N53_HT1.Api.Services.Interfaces;

namespace N53_HT1.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;
    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public IActionResult GetOrders()
    {
        var result = _orderService.Get(order => true)
            .ToList();

        return result.Any() ? Ok(result) : NotFound();
    }

    [HttpGet("{orderId:guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid orderid)
    {
        var result = await _orderService.GetByIdAsync(orderid);

        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create([FromBody] Order order)
    {
        var result = await _orderService.CreateAsync(order);
        return CreatedAtAction(nameof(GetById), new { orderId = result.Id }, result);
    }
}


