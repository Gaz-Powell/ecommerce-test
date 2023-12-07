namespace Plumbing.Ecommerce.Models.DomainModels;

public class Customer
{
    public Customer(string name)
    {
        Name = name;
    }

    public string Name { get; }
}