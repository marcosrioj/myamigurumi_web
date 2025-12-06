using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Application.Common.Interfaces;

public interface ICatalogDbContext
{
    DbSet<Listing> Listings { get; }
    DbSet<Category> Categories { get; }
    DbSet<Store> Stores { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
