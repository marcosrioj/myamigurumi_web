using Catalog.Application.Common.Interfaces;
using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Persistence;

public class CatalogDbContext(DbContextOptions<CatalogDbContext> options) : DbContext(options), ICatalogDbContext
{
    public DbSet<Listing> Listings => Set<Listing>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Store> Stores => Set<Store>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Children)
            .WithOne(c => c.Parent)
            .HasForeignKey(c => c.ParentId);

        modelBuilder.Entity<Listing>()
            .Property(l => l.Tags)
            .HasColumnType("text[]");

        modelBuilder.Entity<Listing>()
            .Property(l => l.MediaUrls)
            .HasColumnType("text[]");

        modelBuilder.Entity<Listing>()
            .Property(l => l.Variations)
            .HasColumnType("jsonb");

        Seed(modelBuilder);
    }

    private static void Seed(ModelBuilder modelBuilder)
    {
        var animalsId = Guid.NewGuid();
        var seasonalId = Guid.NewGuid();
        var storeId = Guid.NewGuid();
        var listingId = Guid.NewGuid();

        modelBuilder.Entity<Category>().HasData(
            new Category { Id = animalsId, Name = "Animals", Slug = "animals" },
            new Category { Id = seasonalId, Name = "Seasonal", Slug = "seasonal" }
        );

        modelBuilder.Entity<Store>().HasData(
            new Store { Id = storeId, Name = "Cozy Stitches", Description = "Handcrafted plushies and seasonal drops", LogoUrl = "/images/stores/cozy.png", OwnerEmail = "artisan@myamigurumi.com" }
        );

        modelBuilder.Entity<Listing>().HasData(
            new Listing
            {
                Id = listingId,
                Title = "Forest Fox",
                Description = "Charming crochet fox with custom color options.",
                Price = 45.00m,
                Stock = 12,
                CategoryId = animalsId,
                StoreId = storeId,
                IsCustomizable = true,
                Tags = new[] { "fox", "animal", "woodland" },
                MediaUrls = new[] { "/media/fox-1.jpg", "/media/fox-2.jpg" },
                Variations = new[]
                {
                    new ListingVariation { Id = Guid.NewGuid(), Name = "Classic", Color = "Rust", Size = "M", Price = 45.00m, Stock = 6 },
                    new ListingVariation { Id = Guid.NewGuid(), Name = "Snow", Color = "White", Size = "M", Price = 47.00m, Stock = 6 }
                }
            }
        );
    }
}
