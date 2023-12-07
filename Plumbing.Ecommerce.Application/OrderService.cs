using Plumbing.Ecommerce.DataProvider.Repositories;
using Plumbing.Ecommerce.Models.ApiRequests;
using Plumbing.Ecommerce.Models.DomainModels;

namespace Plumbing.Ecommerce.Application;

public class OrderService : IOrderService
{
    private readonly IProductRepository _productRepository;
    private readonly IOrderRepository _orderRepository;

    public OrderService(IProductRepository productRepository, IOrderRepository orderRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
    }

    public async Task CreateOrderAsync(OrderRequest orderRequest)
    {
        var productIds = orderRequest.OrderLines.Select(ol => ol.ProductId).ToList();

        var requestProducts = _productRepository.GetProductsByProductIds(productIds);

        var domainCustomer = new Customer(orderRequest.OrderCustomer.Name);

        var order = new Order(0, orderRequest.OrderDate, domainCustomer, orderRequest.PostagePrice,
            orderRequest.DeliveryInstructions, orderRequest.TaxRate, orderRequest.PaymentCardDetails);

        //check product details on order match the product details retrieved from repository
        foreach (var orderRequestLineItem in orderRequest.OrderLines)
        {
            var requestProduct = requestProducts.SingleOrDefault(p => p.Id == orderRequestLineItem.ProductId);

            if (requestProduct == null)
            {
                throw new InvalidOperationException(
                    $"Ordered product with ID {orderRequestLineItem.ProductId} was not found in the product repository");
            }

            var product = new Product(requestProduct.Name, requestProduct.Id, requestProduct.UnitPrice);

            if (!product.NameEquals(orderRequestLineItem.ProductName))
                throw new InvalidOperationException(
                    $"Ordered product ID {requestProduct.Id} {orderRequestLineItem.ProductName} did not match product repository name: {requestProduct.Name}");

            if (!product.UnitPriceEquals(orderRequestLineItem.UnitPrice))
                throw new InvalidOperationException(
                    $"Ordered product ID {requestProduct.Id} unit price {orderRequestLineItem.UnitPrice} did not match product repository price: {requestProduct.UnitPrice}");

            order.AddLineItem(new LineItem(product, orderRequestLineItem.Quantity, orderRequestLineItem.UnitPrice));
        }

        await _orderRepository.SaveOrderAsync(order);
    }
}