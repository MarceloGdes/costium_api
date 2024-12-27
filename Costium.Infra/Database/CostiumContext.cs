using Costium.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Costium.Infra.Database.Context;
public class CostiumContext(DbContextOptions<CostiumContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .Property(e => e.Id)
            .HasConversion(
                ulid => ulid.ToString(),
                value => Ulid.Parse(value));
    }
}
