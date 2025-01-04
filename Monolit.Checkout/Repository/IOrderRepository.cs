using Monolit.Checkout.Domain.Entities;
using Monolit.Checkout.Domain.Models;

namespace Monolit.Checkout.Repository;

public interface IOrderRepository
{
 public Task<OrderModel> CreateOrder(OrderEntity order);
}
