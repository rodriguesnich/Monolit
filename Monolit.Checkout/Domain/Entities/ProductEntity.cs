using System;

namespace Monolit.Checkout.Domain.Entities;

public class ProductEntity
{
    public Guid Id {get; set;}
    public string Name {get; set;} = string.Empty;
    public double Price {get; set;}
}
