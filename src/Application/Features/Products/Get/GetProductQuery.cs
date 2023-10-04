using Application.Abstractions.Messaging;
using Domain.Entities.Products;

namespace Application.Features.Products.Get;

public record GetProductQuery(ProductId ProductId) : IQuery<ProductResponse>;

public record ProductResponse(
    Guid Id,
    string Name,
    string Sku,
    string Currency,
    decimal Amount);