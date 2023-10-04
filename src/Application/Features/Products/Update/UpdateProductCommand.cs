using Application.Abstractions.Messaging;
using Domain.Entities.Products;

namespace Application.Features.Products.Update;

public record UpdateProductCommand(
    ProductId ProductId,
    string Name,
    string Sku,
    string Currency,
    decimal Amount
    ) : ICommand;

public record UpdateProductRequest(
    string Name,
    string Sku,
    string Currency,
    decimal Amount);
