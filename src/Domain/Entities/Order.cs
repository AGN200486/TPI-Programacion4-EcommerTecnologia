using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Order
{
    [Key]
    public int Id { get; set; }

    public decimal Total { get; set; }

    // Relación con Client (1 Client -> muchas Orders)
    public int ClientId { get; set; }
    public Client Client { get; set; } = null!;

    // Relación con Products (1 Order -> muchos Products)
    public ICollection<Product> Products { get; set; } = new List<Product>();

    // Constructor sin parámetros requerido por Entity Framework Core
    public Order() { }
}