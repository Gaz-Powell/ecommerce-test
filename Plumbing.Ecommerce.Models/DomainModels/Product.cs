namespace Plumbing.Ecommerce.Models.DomainModels;

public class Product
{
    public Product(string name, uint id, decimal unitPrice)
    {
        Name = name;
        Id = id;
        UnitPrice = unitPrice;
    }

    public string Name { get; set; }
    public uint Id { get; set; }
    public decimal UnitPrice { get; set; }

    public bool UnitPriceEquals(decimal orderUnitPrice)
    {
        return UnitPrice == orderUnitPrice;
    }

    public bool NameEquals(string orderProductName)
    {
        return Name.Equals(orderProductName, StringComparison.OrdinalIgnoreCase);
    }
}