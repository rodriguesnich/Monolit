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
        };

        _context.Products.Add(productModel);
        await _context.SaveChangesAsync();

        return productModel;
    }
    
    public async Task<List<ProductModel>> ListProducts()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<ProductModel> GetProduct(Guid productId)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
        return product ?? throw new KeyNotFoundException($"Product with ID {productId} not found");
    }

    public async Task<ProductModel> UpdateProduct(UpdateProductEntity productEntity)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productEntity.Id);
        if (product == null)
        {
            throw new KeyNotFoundException($"Product with ID {productEntity.Id} not found");
        }

        product.Name = productEntity.Name;
        product.Description = productEntity.Description;
        product.Price = productEntity.Price;

        _context.Products.Update(product);
        await _context.SaveChangesAsync();

        return product;
    }

    public async Task DeleteProduct(Guid productId)
    {
        var product = await _context.Products.FindAsync(productId);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
