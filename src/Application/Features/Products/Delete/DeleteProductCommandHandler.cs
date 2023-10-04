using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Entities.Products;
using Domain.Errors;
using FluentResults;

namespace Application.Features.Products.Delete;

internal sealed class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        Product? product = await _productRepository.FindByIdAsync(request.ProductId, cancellationToken);
        if (product is null)
        {
            return Result.Fail(DomainErrors.ProductNotFoundError(request.ProductId));
        }
        _productRepository.Remove(product);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}
