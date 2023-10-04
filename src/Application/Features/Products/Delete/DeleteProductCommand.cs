using Application.Abstractions.Messaging;
using Domain.Entities.Products;

namespace Application.Features.Products.Delete;

public record DeleteProductCommand(ProductId ProductId) : ICommand;
