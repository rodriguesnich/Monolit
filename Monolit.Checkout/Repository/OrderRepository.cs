using Monolit.Checkout.Domain.Entities;
using Monolit.Checkout.Domain.Models;

namespace Monolit.Checkout.Repository;

public class OrderRepository : IOrderRepository
{
    public OrderRepository()
    { }

    public Task<OrderModel> CreateOrder(OrderEntity order)
    {
        throw new NotImplementedException();
    }
}
