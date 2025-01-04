namespace Monolit.GeneralDomain.Gateways.OrderGateway.Dtos;

public class InputCreateOrderDto
{
    public Guid ClientId {get; set;}
    public List<ProductDto> Products {get;set;} = [];
}

public class ProductDto
{
    public Guid Id {get;set;}
    public int Quantity {get;set;}
}

public class OutputCreateOrderDto
{
    public Guid OrderId {get;set;}
}
