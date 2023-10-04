namespace Domain.Entities;

public sealed class Product
{
    public ProductId Id { get; private set; } = default!;
    public string Name { get; private set; } = string.Empty;
    public Money Price { get; private set; } = default!;
    public Sku Sku { get; private set; } = default!;
}
