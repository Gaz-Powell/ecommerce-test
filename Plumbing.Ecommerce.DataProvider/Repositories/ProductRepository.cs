using Plumbing.Ecommerce.DataProvider.Models;

namespace Plumbing.Ecommerce.DataProvider.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly OrderContext _orderContext;

    public ProductRepository(OrderContext orderContext)
    {
        _orderContext = orderContext ?? throw new ArgumentNullException(nameof(orderContext));
    }

    public IQueryable<Product> GetProductsByProductIds(IReadOnlyList<uint> productIds)
    {
        return _orderContext.Products.Where(p => productIds.Contains(p.Id));
    }
}