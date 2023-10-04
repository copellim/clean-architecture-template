using Application.Features.Products.Create;
using Application.Features.Products.Delete;
using Application.Features.Products.Get;
using Application.Features.Products.Update;
using Carter;
using Domain.Entities.Products;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Endpoints
{
    public class Products : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("products", async (CreateProductCommand command, ISender sender) =>
            {
                await sender.Send(command);
                return Results.Ok();
            });

            app.MapGet("products/{id:guid}", async (Guid id, ISender sender) =>
            {
                Result<ProductResponse>? productResponse =
                    await sender.Send(new GetProductQuery(new ProductId(id)));

                if (productResponse.IsFailed || productResponse.Value is null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(productResponse.Value);
            });

            app.MapPut("products/{id:guid}", async (Guid id, [FromBody] UpdateProductRequest request, ISender sender) =>
            {
                UpdateProductCommand command = new(
                    new ProductId(id),
                    request.Name,
                    request.Sku,
                    request.Currency,
                    request.Amount);

                await sender.Send(command);

                return Results.NoContent();
            });

            app.MapDelete("products/{id:guid}", async (Guid id, ISender sender) =>
            {
                Result result = await sender.Send(new DeleteProductCommand(new ProductId(id)));

                if (result.IsFailed)
                {
                    return Results.NotFound(result.Errors);
                }
                return Results.NoContent();
            });
        }
    }
}
