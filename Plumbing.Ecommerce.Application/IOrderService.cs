using Plumbing.Ecommerce.Models.ApiRequests;

namespace Plumbing.Ecommerce.Application;

public interface IOrderService
{
    Task CreateOrderAsync(OrderRequest orderRequest);
}