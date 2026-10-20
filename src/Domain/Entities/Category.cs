namespace Domain.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    // Propiedad de navegación para EF Core
    public ICollection<Product> Products { get; set; } = new List<Product>(); // lista que guarda todos los productos pertenecientes a esa categoría

    // Constructor sin parametros requerido por Entity Framework Core
    public Category() { }
}