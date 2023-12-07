namespace Plumbing.Ecommerce.DataProvider.Models;

public class Order
{
    public uint? Id { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal PostagePrice { get; set; }
    public string DeliveryInstructions { get; set; }
    public decimal TaxRate { get; set; }
    public string PaymentCardDetails { get; set; }

    public virtual Customer Customer { get; set; }
    public virtual ICollection<LineItem> LineItems { get; set; }
}