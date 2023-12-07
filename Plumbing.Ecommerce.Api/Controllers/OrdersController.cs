using Microsoft.AspNetCore.Mvc;
using Plumbing.Ecommerce.Application;
using Plumbing.Ecommerce.Models.ApiRequests;

namespace Plumbing.Ecommerce.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateAsync([FromBody] OrderRequest order)
    {
        if (order.OrderCustomer == null)
            return BadRequest("Order must include a customer");

        if (!order.OrderLines.Any())
            return BadRequest("Order must include at least one order line");

        await _orderService.CreateOrderAsync(order);

        return Ok();
    }
}