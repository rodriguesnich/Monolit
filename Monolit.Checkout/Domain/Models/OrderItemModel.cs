using Monolit.GeneralDomain;

namespace Monolit.Checkout.Domain.Models;

public class OrderItemModel : BaseEntity
{
    public Guid ProductId {get;set;}
    public int Quantity {get;set;}
}
