namespace Plumbing.Ecommerce.Models.ApiRequests;

public record OrderRequestLineItem(
    uint ProductId,
    string ProductName,
    decimal UnitPrice,
    uint Quantity
);