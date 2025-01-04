
using Monolit.GeneralDomain.Gateways.OrderGateway.Dtos;

namespace Monolit.GeneralDomain.Gateways.OrderGateway;

public interface IOrderGateWay
{
    public Task<OutputCreateOrderDto> CreateOrder(InputCreateOrderDto order);
}
