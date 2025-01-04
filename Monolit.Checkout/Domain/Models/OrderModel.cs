using Monolit.GeneralDomain;

namespace Monolit.Checkout.Domain.Models;

public class OrderModel : BaseEntity
{
    public string Status {get;set;} = string.Empty;
    public double Total {get;set;}
    public Guid ClientId {get;set;}
    public List<OrderItemModel> Products {get;set;} = [];
}
