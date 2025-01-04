using System.ComponentModel.DataAnnotations;

namespace Monolit.Product.Domain.Entities;

public class ProductEntity
{
    [Required]
    [StringLength(100, ErrorMessage = "Name length can't be more than 100.")]
    public string Name { get; set; } = string.Empty;

    [Range(0.00, 10000.00, ErrorMessage = "Price must be between 0.00 and 10000.00.")]
    public double Price { get; set; }

    [Required]
    public string Description { get; set; } = string.Empty;
}
