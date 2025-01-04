using AutoMapper;
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
    private readonly IMapper _mapper;

    public ProductGateway(GetProductUseCase getProductUseCase, DeleteProductUseCase deleteProductUseCase, CreateProductUseCase createProductUseCase, ListProductsUseCase listProductsUseCase, UpdateProductUseCase updateProductUseCase, IMapper mapper)
    {
        _createProductUseCase = createProductUseCase;
        _listProductUsecase = listProductsUseCase;
        _getProductUseCase = getProductUseCase;
        _updateProductUseCase = updateProductUseCase;
        _deleteProductUseCase = deleteProductUseCase;
        _mapper = mapper;
    }

    public async Task<OutPutGetProductDto> CreateProduct(InputCreateProduct product)
    {
        var newProduct = await _createProductUseCase.Execute(product);
        return _mapper.Map<OutPutGetProductDto>(newProduct);
    }

    public async Task<List<OutPutGetProductDto>> ListProducts()
    {
        var products = await _listProductUsecase.Execute();
        return _mapper.Map<List<OutPutGetProductDto>>(products);
    }

    public async Task<OutPutGetProductDto> GetProduct(Guid productId)
    {
        var product = await _getProductUseCase.Execute(productId);
        return _mapper.Map<OutPutGetProductDto>(product);
    }

    public async Task<OutPutGetProductDto> UpdateProduct(Guid productId, InputCreateProduct product)
    {
        var updated = await _updateProductUseCase.Execute(productId, product);
         return _mapper.Map<OutPutGetProductDto>(updated);
    }
    
    public async Task DeleteProdut(Guid productId)
    {
        await _deleteProductUseCase.Execute(productId);
    }
}
