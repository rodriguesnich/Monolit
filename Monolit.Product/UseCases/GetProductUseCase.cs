using Monolit.Product.Domain.Dtos.GetProduct;
using Monolit.Product.Repository;

namespace Monolit.Product.UseCases;

public class GetProductUseCase
{
    private readonly IProductRepository _productRepository;

    public GetProductUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductUseCaseDto> Execute(Guid productId)
    {
        var queryResult = await _productRepository.GetProduct(productId);

        return new ProductUseCaseDto(){
            Id = queryResult.Id,
            Name = queryResult.Name,
            Price = queryResult.Price
        };
    }
}
