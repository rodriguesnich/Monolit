using Monolit.GeneralDomain.Gateways.ProductGateway;
using Monolit.GeneralDomain.Gateways.ProductGateway.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Monolit.Api.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this WebApplication app)
    {
        var productGroup = app.MapGroup("/product").WithTags("Product").WithOpenApi();

        productGroup.MapPost("/", async (InputCreateProduct product, IProductGateway productGateway) =>
        {
            try
            {
                var newProduct = await productGateway.CreateProduct(product);
                return newProduct != null ? Results.Ok(newProduct) : Results.NotFound();
            }
            catch (ValidationException ex)
            {
                return Results.BadRequest(new { Errors = ex.Message.Split("; ") });
            }
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

        productGroup.MapPut("/{id}", async (Guid id, InputCreateProduct product, IProductGateway productGateway) =>
        {
            try
            {
                var updated = await productGateway.UpdateProduct(id, product);
                return updated != null ? Results.Ok(updated) : Results.NotFound();
            }
            catch (ValidationException ex)
            {
                return Results.BadRequest(new { Errors = ex.Message.Split("; ") });
            }
        });

        productGroup.MapDelete("/{id}", async (Guid id, IProductGateway productGateway) =>
        {
            await productGateway.DeleteProdut(id);
            return Results.Ok();
        });
    }
}
