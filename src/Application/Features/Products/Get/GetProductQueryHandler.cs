using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.Errors;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Products.Get;

internal sealed class GetProductQueryHandler : IQueryHandler<GetProductQuery, ProductResponse>
{
    private readonly IApplicationDbContext _dbContext;

    public GetProductQueryHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<ProductResponse>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        ProductResponse? product = await _dbContext
            .Products
            .Where(p => p.Id == request.ProductId)
            .Select(p => new ProductResponse(
                p.Id.Value,
                p.Name,
                p.Sku.Value,
                p.Price.Currency,
                p.Price.Amount))
            .FirstOrDefaultAsync(cancellationToken);

        if (product is null)
        {
            return Result.Fail(DomainErrors.ProductNotFoundError(request.ProductId));
        }
        return product;
    }
}
