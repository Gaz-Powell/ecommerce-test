namespace Plumbing.Ecommerce.Models.DomainModels;

public class Order
{
    public Order(uint? id, DateTime orderDate, Customer customer, decimal postagePrice, 
        string deliveryInstructions, decimal taxRate, string paymentCardDetails)
    {
        Id = id;
        OrderDate = orderDate;
        Customer = customer;
        LineItems = new List<LineItem>();
        PostagePrice = postagePrice;
        DeliveryInstructions = deliveryInstructions;
        TaxRate = taxRate;
        PaymentCardDetails = paymentCardDetails;
    }

    public uint? Id { get; set; }
    public DateTime OrderDate { get; set; }
    public Customer Customer { get; set; }
    public List<LineItem> LineItems { get; set; }
    public decimal PostagePrice { get; set; }
    public string DeliveryInstructions { get; set; }
    public decimal TaxRate { get; set; }
    public string PaymentCardDetails { get; set; }

    public void AddLineItem(LineItem lineItem)
    {
        LineItems.Add(lineItem);
    }
}