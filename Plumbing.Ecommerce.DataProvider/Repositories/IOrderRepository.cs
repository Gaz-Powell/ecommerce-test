using Plumbing.Ecommerce.Models.DomainModels;

namespace Plumbing.Ecommerce.DataProvider.Repositories;

public interface IOrderRepository
{
    Task SaveOrderAsync(Order domainOrder);
}