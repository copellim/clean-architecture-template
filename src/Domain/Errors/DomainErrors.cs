using Domain.Entities.Products;
using Domain.Shared;

namespace Domain.Errors;

public static class DomainErrors
{
    public static CustomError ProductNotFoundError(ProductId productId)
        => new("Products.ProductNotFound", $"The product with ID = {productId.Value} was not found");
}
