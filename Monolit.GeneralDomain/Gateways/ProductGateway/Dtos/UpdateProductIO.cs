namespace Monolit.GeneralDomain.Gateways.ProductGateway.Dtos;

public class InputUpdateProduct
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public double Price { get; set; }

    public string Description { get; set; } = string.Empty;
}
