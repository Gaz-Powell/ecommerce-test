namespace Plumbing.Ecommerce.DataProvider.Models;

public class LineItem
{
    public uint? Id { get; set; }
    public Product Product { get; set; }
    public uint Quantity { get; set; }
    public decimal UnitPurchasePrice { get; set; }
    public decimal LineTotal => UnitPurchasePrice * Quantity;

    public virtual Order Order { get; set; }
}