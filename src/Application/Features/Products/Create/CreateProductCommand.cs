using Application.Abstractions.Messaging;

namespace Application.Features.Products.Create;

public record CreateProductCommand(
    string Name,
    string Sku,
    string Currency,
    decimal Amount
    ) : ICommand;