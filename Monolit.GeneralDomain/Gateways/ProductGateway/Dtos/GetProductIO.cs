namespace Monolit.GeneralDomain.Gateways.ProductGateway.Dtos;

public class OutPutGetProductDto
{
    public Guid Id {get; set;}
    public string Name {get; set;} = string.Empty;
    public double Price {get; set;}
}