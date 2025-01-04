using AutoMapper;
using Monolit.GeneralDomain.Gateways.ProductGateway.Dtos;
using Monolit.Product.Domain.Models;
using Monolit.Product.Domain.Dtos;
using Monolit.Product.Domain.Entities;

namespace Monolit.Product.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductEntity, ProductModel>();
        CreateMap<ProductModel, OutputProductUseCase>();
        CreateMap<OutputProductUseCase, OutPutGetProductDto>();
        CreateMap<InputCreateProduct, ProductEntity>();
        CreateMap<InputProductUseCase, OutPutGetProductDto>();
    }
}
