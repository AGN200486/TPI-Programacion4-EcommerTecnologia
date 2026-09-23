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
        // Primero ejecuta la configuracion estandar que trae la clase base DbContext, y despues aplica las reglas personalizadas
        base.OnModelCreating(modelBuilder); // Llama a la implementacion base de EF Core
        
        // indica a EF Core que la regla que sigue se aplica especificamente sobre la entidad Product
        modelBuilder.Entity<Product>()
            //Le dice a Entity Framework que tipo de dato SQL exacto debe usar en la tabla para almacenar price
            .Property(p => p.Price)
            .HasColumnType("TEXT"); // Para no sufrir distorciones por redondeo al almacenar el price en la BDD

        modelBuilder.Entity<Order>()
            .Property(o => o.Total)
            .HasColumnType("TEXT");
    }
}