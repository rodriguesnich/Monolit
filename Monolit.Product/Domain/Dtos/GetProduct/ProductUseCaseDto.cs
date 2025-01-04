namespace Monolit.Product.Domain.Dtos.GetProduct;

public class ProductUseCaseDto
{
    public Guid Id {get; set;}
    public string Name {get; set;} = string.Empty;
    public double Price {get; set;}
}
