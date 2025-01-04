using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Monolit.GeneralDomain.Gateways.ProductGateway.Dtos;
using Monolit.Product.Domain.Dtos;
using Monolit.Product.Domain.Entities;
using Monolit.Product.Repository;

namespace Monolit.Product.UseCases;

public class CreateProductUseCase
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public CreateProductUseCase(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<OutputProductUseCase> Execute(InputCreateProduct product)
    {
        var input = _mapper.Map<ProductEntity>(product);
        ValidateEntity(input);

        var productModel = await _productRepository.CreateProduct(input);

        return _mapper.Map<OutputProductUseCase>(productModel);
    }

     private void ValidateEntity(ProductEntity entity)
    {
        var validationContext = new ValidationContext(entity);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(entity, validationContext, validationResults, validateAllProperties: true);

        if (!isValid)
        {
            var errors = validationResults.Select(vr => vr.ErrorMessage).ToList();
            throw new ValidationException(string.Join("; ", errors));
        }
    }
}
