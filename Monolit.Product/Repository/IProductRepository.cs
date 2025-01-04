using Monolit.Product.Domain.Entities;
using Monolit.Product.Domain.Models;

namespace Monolit.Product.Repository;

public interface IProductRepository
{
    public Task<ProductModel> CreateProduct(ProductEntity product);
    public Task<List<ProductModel>> ListProducts();
    public Task<ProductModel> GetProduct(Guid productId);
    public Task<ProductModel> UpdateProduct(UpdateProductEntity product);
    public Task DeleteProduct(Guid productId);
}
