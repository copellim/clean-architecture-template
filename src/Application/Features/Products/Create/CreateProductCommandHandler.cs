using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Entities.Products;
using FluentResults;

namespace Application.Features.Products.Create;

internal sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(
        IProductRepository productRepository,
        IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        Product product = new(
            new ProductId(Guid.NewGuid()),
            request.Name,
            new Money(request.Currency, request.Amount),
            Sku.Create(request.Sku)!);

        _productRepository.Add(product);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}
