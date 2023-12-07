using Microsoft.EntityFrameworkCore;
using Plumbing.Ecommerce.DataProvider.Models;

namespace Plumbing.Ecommerce.DataProvider;

public class OrderContext : DbContext
{
    public OrderContext(DbContextOptions<OrderContext> options) : base(options)
    {
    }

    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<LineItem> LineItems { get; set; }
    public DbSet<Product> Products { get; set; }
}