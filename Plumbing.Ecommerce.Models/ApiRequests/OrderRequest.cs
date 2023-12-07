namespace Plumbing.Ecommerce.Models.ApiRequests;

public record OrderRequest(
    DateTime OrderDate,
    OrderCustomer OrderCustomer,
    IEnumerable<OrderRequestLineItem> OrderLines,
    decimal TaxRate,
    decimal PostagePrice,
    string DeliveryInstructions,
    string PaymentCardDetails
);