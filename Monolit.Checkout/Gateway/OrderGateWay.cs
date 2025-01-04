using Monolit.GeneralDomain.Gateways.OrderGateway;
using Monolit.GeneralDomain.Gateways.OrderGateway.Dtos;

namespace Monolit.Checkout.Gateway;

public class OrderGateWay : IOrderGateWay
{
    public OrderGateWay()
    { }

    public Task<CreatedOrderDto> CreateOrder(CreateOrderDto order)
    {
        throw new NotImplementedException();
    }
}
