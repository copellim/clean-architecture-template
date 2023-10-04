namespace Domain.Entities.Products;

public sealed class Product
{
    public Product(ProductId id, string name, Money price, Sku sku)
    {
        Id = id;
        Name = name;
        Price = price;
        Sku = sku;
    }

    public ProductId Id { get; private set; } = default!;
    public string Name { get; private set; } = string.Empty;
    public Money Price { get; private set; } = default!;
    public Sku Sku { get; private set; } = default!;

    public void Update(string name, Money price, Sku sku)
    {
        Name = name;
        Price = price;
        Sku = sku;
    }
}
