namespace Monolit.Checkout.Domain.Entities;

public enum OrderStatus
{
    Pending,
    Approved
}

public class OrderEntity
{
    public OrderStatus Status {get;set;}
    public double Total {get;set;}
    public Guid ClientId {get;set;}
    public List<OrderItemEntity> Products {get;set;} = [];

    public OrderEntity CalcTotal()
    {
        Total = 0;
        foreach (var orderItem in Products)
        {
            Total += orderItem.Product.Price * orderItem.Quantity;   
        }
        return this;
    }
}
