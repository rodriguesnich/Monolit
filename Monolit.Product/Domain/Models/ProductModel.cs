using System.ComponentModel.DataAnnotations;
using Monolit.GeneralDomain;

namespace Monolit.Product.Domain.Models;

public class ProductModel : BaseEntity
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Range(0.00, 10000.00)]
    public double Price { get; set; }

    public string Description { get; set; } = string.Empty;
    
    [Required]
    public bool IsActive {get; set;}
}
