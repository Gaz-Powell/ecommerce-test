namespace Plumbing.Ecommerce.DataProvider.Models
{
    public class Product
    {
        public string Name { get; set; }
        public uint Id { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
