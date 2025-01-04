using Monolit.GeneralDomain.Gateways.ProductGateway;
using Monolit.GeneralDomain.Gateways.ProductGateway.Dtos;
using Monolit.Product.UseCases;

namespace Monolit.Product.Gateway;

public class ProductGateway : IProductGateway
{
    private readonly CreateProductUseCase _createProductUseCase;
    private readonly ListProductsUseCase _listProductUsecase;
    private readonly GetProductUseCase _getProductUseCase;
    private readonly UpdateProductUseCase _updateProductUseCase;
    private readonly DeleteProductUseCase _deleteProductUseCase;

    public ProductGateway(GetProductUseCase getProductUseCase, DeleteProductUseCase deleteProductUseCase, CreateProductUseCase createProductUseCase, ListProductsUseCase listProductsUseCase, UpdateProductUseCase updateProductUseCase)
    {
        _createProductUseCase = createProductUseCase;
        _listProductUsecase = listProductsUseCase;
        _getProductUseCase = getProductUseCase;
        _updateProductUseCase = updateProductUseCase;
        _deleteProductUseCase = deleteProductUseCase;
    }

    public async Task<OutPutGetProductDto> CreateProduct(InputCreateProduct product)
    {
        var newProduct = await _createProductUseCase.Execute(product);
        return new OutPutGetProductDto()
        {
            Id = newProduct.Id,
            Name = newProduct.Name,
            Price = newProduct.Price
        };
    }

    public async Task<List<OutPutGetProductDto>> ListProducts()
    {
        var products = await _listProductUsecase.Execute();

        return products.Select(product => new OutPutGetProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        }).ToList();
    }

    public async Task<OutPutGetProductDto> GetProduct(Guid productId)
    {
        var product = await _getProductUseCase.Execute(productId);
        return new OutPutGetProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        };
    }

    public async Task<OutPutGetProductDto> UpdateProduct(InputUpdateProduct product)
    {
        var updated = await _updateProductUseCase.Execute(product);
        return new OutPutGetProductDto{
            Id = updated.Id,
            Name = updated.Name,
            Price = updated.Price
        };
    }
    
    public async Task DeleteProdut(Guid productId)
    {
        await _deleteProductUseCase.Execute(productId);
    }
}
