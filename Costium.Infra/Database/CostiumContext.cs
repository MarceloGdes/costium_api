using Costium.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Costium.Infra.Database.Context;
public class CostiumContext(DbContextOptions<CostiumContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
}
