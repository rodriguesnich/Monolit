using AutoMapper;
using Monolit.Product.Domain.Dtos;
using Monolit.Product.Repository;

namespace Monolit.Product.UseCases;

public class GetProductUseCase
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public GetProductUseCase(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<OutputProductUseCase> Execute(Guid productId)
    {
        var queryResult = await _productRepository.GetProduct(productId);
        return _mapper.Map<OutputProductUseCase>(queryResult);
    }
}
