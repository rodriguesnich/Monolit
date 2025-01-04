
using Monolit.Product.Repository;

namespace Monolit.Product.UseCases;

public class DeleteProductUseCase
{
    private readonly IProductRepository _productRepository;

    public DeleteProductUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }


public async Task Execute(Guid productId)
    {
        await _productRepository.DeleteProduct(productId);
    }
}
