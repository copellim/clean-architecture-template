namespace Domain.Entities.Products;

public interface IProductRepository
{
    void Add(Product product);
    void Remove(Product product);
    void Update(Product product);
    Task<Product> FindByIdAsync(ProductId productId, CancellationToken cancellationToken);
}
