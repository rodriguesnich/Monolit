using Monolit.GeneralDomain.Gateways.ProductGateway;
using Monolit.GeneralDomain.Gateways.ProductGateway.Dtos;

namespace Monolit.Api.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this WebApplication app)
    {
        var productGroup = app.MapGroup("/product").WithTags("Product").WithOpenApi();

        productGroup.MapPost("/", async (InputCreateProduct product, IProductGateway productGateway) =>
        {
            var newProduct = await productGateway.CreateProduct(product);
            return product != null ? Results.Ok(product) : Results.NotFound();
        });

        productGroup.MapGet("/", async (IProductGateway productGateway) => 
        {
            var products = await productGateway.ListProducts();
            return products != null ? Results.Ok(products) : Results.NotFound();
        });

        productGroup.MapGet("/{id}", async (Guid id, IProductGateway productGateway) =>
        {
            var product = await productGateway.GetProduct(id);
            return product != null ? Results.Ok(product) : Results.NotFound();
        });

        productGroup.MapPut("/{id}", async (Guid id, InputUpdateProduct product, IProductGateway productGateway) =>
        {
            var updated = await productGateway.UpdateProduct(product);
            return updated != null ? Results.Ok(updated) : Results.NotFound();
        });

        productGroup.MapDelete("/{id}", async (Guid id, IProductGateway productGateway) =>
        {
            await productGateway.DeleteProdut(id);
            return Results.Ok();
        });
    }
}
