using Monolit.GeneralDomain.Gateways.ProductGateway.Dtos;

namespace Monolit.GeneralDomain.Gateways.ProductGateway;

public interface IProductGateway
{
    public Task<OutPutGetProductDto> CreateProduct(InputCreateProduct product);
    public Task<List<OutPutGetProductDto>> ListProducts();
    public Task<OutPutGetProductDto> GetProduct(Guid productId);
    public Task<OutPutGetProductDto> UpdateProduct(Guid Id, InputCreateProduct product);
    public Task DeleteProdut(Guid productId);
}
