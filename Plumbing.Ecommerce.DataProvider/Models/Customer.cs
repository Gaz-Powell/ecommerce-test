﻿namespace Plumbing.Ecommerce.DataProvider.Models;

public class Customer
{
    public string Name { get; set; }

    public virtual ICollection<Order> Orders { get; set; }
}