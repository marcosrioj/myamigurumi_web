using Identity.Application.Common.Interfaces;
using Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Persistence;

public class IdentityDbContext(DbContextOptions<IdentityDbContext> options) : DbContext(options), IIdentityDbContext
{
    public DbSet<AppUser> Users => Set<AppUser>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var admin = new AppUser
        {
            Id = Guid.NewGuid(),
            Email = "admin@myamigurumi.com",
            Role = "admin",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("changeit")
        };

        modelBuilder.Entity<AppUser>().HasData(admin);
    }
}
