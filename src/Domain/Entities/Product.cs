using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Product
{

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public double Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool Active { get; set; } = true;
    public int Stock { get; set; }

    // Clave foránea según diagrama
    public int CategoryId { get; set; }
    public Category? Category { get; set; }


    // Constructor sin parametros requerido por Entity Framework Core
    public Product() { }
}