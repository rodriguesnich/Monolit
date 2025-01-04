using Monolit.GeneralDomain.Gateways.ProductGateway.Dtos;
using Monolit.Product.Domain.Dtos;
using Monolit.Product.Repository;

namespace Monolit.Product.UseCases;

public class UpdateProductUseCase
{
    private readonly IProductRepository _productRepository;
    private readonly CreateProductUseCase _createProductUseCase;

    public UpdateProductUseCase(IProductRepository productRepository, CreateProductUseCase createProductUseCase)
    {
        _productRepository = productRepository;
        _createProductUseCase = createProductUseCase;
    }

    public async Task<OutputProductUseCase> Execute(Guid productId, InputCreateProduct product)
    {
        try
        {
            await _productRepository.DeleteProduct(productId);
        }
        catch (KeyNotFoundException ex)
        {
            throw new Exception("Product not found", ex);
        }

        return await _createProductUseCase.Execute(product);        
    }
}
