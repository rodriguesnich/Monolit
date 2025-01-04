namespace Monolit.Checkout.Domain.Entities;

public class OrderItemEntity
{
    public required ProductEntity Product {get;set;}
    public int Quantity {get;set;}
}
