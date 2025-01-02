using Costium.Domain.Models;
using Costium.Infra.Utils;
using Microsoft.EntityFrameworkCore;

namespace Costium.Infra.Database.Context;
public class CostiumContext(DbContextOptions<CostiumContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {   
        //Configurando o conversor de Ulid para String.
        configurationBuilder.Properties<Ulid>()
            .HaveConversion<UlidToStringConverter>()
            .HaveMaxLength(26); // Garantir o comprimento adequado para armazenar ULID

    }
}
