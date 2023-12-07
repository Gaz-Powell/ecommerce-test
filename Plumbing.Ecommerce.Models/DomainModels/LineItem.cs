namespace Plumbing.Ecommerce.Models.DomainModels;

public class LineItem
{
    public LineItem(Product product, uint quantity, decimal unitPrice)
    {
        if (quantity == 0) throw new ArgumentException("Quantity must be greater than 0");

        Product = product;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    public Product Product { get; set; }
    public uint Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}