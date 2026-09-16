using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); // Llama a la implementación base de EF Core
        
        // indica a EF Core que la regla que sigue se aplica específicamente sobre la entidad Product
        modelBuilder.Entity<Product>()
            //Le dice a Entity Framework qué tipo de dato SQL exacto debe usar en la tabla para almacenar price
            .Property(p => p.Price)
            .HasColumnType("TEXT");

        modelBuilder.Entity<Order>()
            .Property(o => o.Total)
            .HasColumnType("TEXT");
    }
}