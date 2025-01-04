using AutoMapper;
using Monolit.Product.Domain.Dtos;
using Monolit.Product.Repository;

namespace Monolit.Product.UseCases;

public class ListProductsUseCase
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ListProductsUseCase(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task<List<OutputProductUseCase>> Execute()
    {
        var queryResult = await _productRepository.ListProducts();

        return _mapper.Map<List<OutputProductUseCase>>(queryResult);
    }
}
