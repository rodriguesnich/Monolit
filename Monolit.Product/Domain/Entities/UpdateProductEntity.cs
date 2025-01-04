namespace Monolit.Product.Domain.Entities;

public class UpdateProductEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public double Price { get; set; }

    public string Description { get; set; } = string.Empty;
}
