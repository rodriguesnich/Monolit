namespace Monolit.GeneralDomain.Gateways.ProductGateway.Dtos;

public class InputCreateProduct
{
    public string Name { get; set; } = string.Empty;

    public double Price { get; set; }

    public string Description { get; set; } = string.Empty;
}