using Monolit.GeneralDomain.Gateways.ProductGateway.Dtos;
using Monolit.Product.Domain.Dtos.GetProduct;
using Monolit.Product.Domain.Entities;
using Monolit.Product.Repository;

namespace Monolit.Product.UseCases;

public class UpdateProductUseCase
{
    private readonly IProductRepository _productRepository;

    public UpdateProductUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductUseCaseDto> Execute(InputUpdateProduct product)
    {
        var existingProduct = await _productRepository.GetProduct(product.Id);
        if (existingProduct != null)
        {
         throw new Exception("Product not found");    
        }

        var updateProductEntity = new UpdateProductEntity
        {
            Id = existingProduct.Id,
            Name = product.Name,
            Price = product.Price,
        };

        var updatedProduct = await _productRepository.UpdateProduct(updateProductEntity);

        return new ProductUseCaseDto
        {
            Id = updatedProduct.Id,
            Name = updatedProduct.Name,
            Price = updatedProduct.Price,
        };
    }
}
