using Monolit.Product.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Monolit.Product.Domain.Entities;

namespace Monolit.Product.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ProductDbContext _context;

    public ProductRepository(ProductDbContext context) 
    {
        _context = context;
    }

    public async Task<ProductModel> CreateProduct(ProductEntity productEntity)
    {
        var productModel = new ProductModel
        {
            Name = productEntity.Name,
            Description = productEntity.Description,
            Price = productEntity.Price,
            IsActive = true,
        };

        _context.Products.Add(productModel);
        await _context.SaveChangesAsync();

        return productModel;
    }
    
    public async Task<List<ProductModel>> ListProducts()
    {
        return await _context.Products.Where(p => p.IsActive).ToListAsync();
    }

    public async Task<ProductModel> GetProduct(Guid productId)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
        return product ?? throw new KeyNotFoundException($"Product with ID {productId} not found");
    }

   public async Task DeleteProduct(Guid productId)
    {
        var product = await _context.Products.FindAsync(productId);
        if (product != null)
        {
            product.IsActive = false;
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
