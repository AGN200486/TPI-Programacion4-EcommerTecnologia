using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Product
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Image { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string Description { get; set; } = string.Empty;

    public bool Active { get; set; } = true;

    public int Stock { get; set; }

    // Constructor sin parámetros requerido por Entity Framework Core
    public Product() { }
}