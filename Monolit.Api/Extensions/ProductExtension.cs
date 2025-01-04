using Microsoft.EntityFrameworkCore;
using Monolit.GeneralDomain.Gateways.ProductGateway;
using Monolit.Product.Gateway;
using Monolit.Product.Repository;
using Monolit.Product.UseCases;
using Monolit.Product.Mapping;

namespace Monolit.Api.Extensions;

public static class ProductExtension
{
    public static void MapProductDependencies(this WebApplicationBuilder build)
    {
        build.Services.AddDbContext<ProductDbContext>(options =>
        options.UseSqlite(build.Configuration.GetConnectionString("ProductDatabase")));

        build.Services.AddAutoMapper(typeof(MappingProfile));

        build.Services.AddTransient<IProductRepository, ProductRepository>();
        build.Services.AddTransient<IProductGateway, ProductGateway>();
        build.Services.AddScoped<CreateProductUseCase>();
        build.Services.AddScoped<ListProductsUseCase>();
        build.Services.AddScoped<GetProductUseCase>();
        build.Services.AddScoped<UpdateProductUseCase>();
        build.Services.AddScoped<DeleteProductUseCase>();
    }
}
