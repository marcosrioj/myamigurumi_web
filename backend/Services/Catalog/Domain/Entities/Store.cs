namespace Catalog.Domain.Entities;

public class Store
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LogoUrl { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string OwnerEmail { get; set; } = string.Empty;
    public ICollection<Listing> Listings { get; set; } = new List<Listing>();
}
