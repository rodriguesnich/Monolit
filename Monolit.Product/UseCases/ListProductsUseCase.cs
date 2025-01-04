using Monolit.Product.Domain.Dtos.GetProduct;
using Monolit.Product.Repository;

namespace Monolit.Product.UseCases;

public class ListProductsUseCase
{
    private readonly IProductRepository _productRepository;

    public ListProductsUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<ProductUseCaseDto>> Execute()
    {
        var queryResult = await _productRepository.ListProducts();

        return queryResult.Select(product => new ProductUseCaseDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        }).ToList();
    }
}
