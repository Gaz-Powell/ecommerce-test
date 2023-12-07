using Plumbing.Ecommerce.DataProvider.Models;
using DomainOrder = Plumbing.Ecommerce.Models.DomainModels.Order;

namespace Plumbing.Ecommerce.DataProvider.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly OrderContext _orderContext;

    public OrderRepository(OrderContext orderContext)
    {
        _orderContext = orderContext ?? throw new ArgumentNullException(nameof(orderContext));
    }

    public async Task SaveOrderAsync(DomainOrder domainOrder)
    {
        var customer = new Customer
        {
            Name = domainOrder.Customer.Name
        };

        var lineItems = domainOrder.LineItems.Select(li => new LineItem
        {
            Product = new Product
            {
                Name = li.Product.Name,
                UnitPrice = li.Product.UnitPrice,
            },
            Quantity = li.Quantity,
            UnitPurchasePrice = li.UnitPrice
        }).ToList();

        var order = new Order
        {
            OrderDate = domainOrder.OrderDate,
            PostagePrice = domainOrder.PostagePrice,
            DeliveryInstructions = domainOrder.DeliveryInstructions,
            TaxRate = domainOrder.TaxRate,
            PaymentCardDetails = domainOrder.PaymentCardDetails,
            Customer = customer,
            LineItems = lineItems
        };

        await _orderContext.Orders.AddAsync(order);
        await _orderContext.LineItems.AddRangeAsync(lineItems);
        await _orderContext.Customers.AddAsync(customer);
        await _orderContext.SaveChangesAsync();
    }
}