using Plumbing.Ecommerce.DataProvider.Models;

namespace Plumbing.Ecommerce.DataProvider.Repositories;

public interface IProductRepository
{
    IQueryable<Product> GetProductsByProductIds(IReadOnlyList<uint> productIds);
}