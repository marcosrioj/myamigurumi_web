namespace Catalog.Domain.Entities;

public class Listing
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string[] Tags { get; set; } = Array.Empty<string>();
    public string[] MediaUrls { get; set; } = Array.Empty<string>();
    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }
    public Guid StoreId { get; set; }
    public Store? Store { get; set; }
    public bool IsCustomizable { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public ListingVariation[] Variations { get; set; } = Array.Empty<ListingVariation>();
}

public class ListingVariation
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public string Size { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
}
