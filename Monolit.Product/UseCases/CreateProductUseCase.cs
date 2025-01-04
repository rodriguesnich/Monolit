using Monolit.GeneralDomain.Gateways.ProductGateway.Dtos;
using Monolit.Product.Domain.Dtos.GetProduct;
using Monolit.Product.Domain.Entities;
using Monolit.Product.Repository;

namespace Monolit.Product.UseCases;

public class CreateProductUseCase
{
    private readonly IProductRepository _productRepository;

    public CreateProductUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductUseCaseDto> Execute(InputCreateProduct product)
    {
        ProductEntity input = new ProductEntity(){
            Name = product.Name,
            Description = product.Description,
            Price = product.Price
        };

        var productModel = await _productRepository.CreateProduct(input);

        return new ProductUseCaseDto() {
            Id = productModel.Id,
            Name = productModel.Name,
            Price = product.Price,
        };
    }
}
