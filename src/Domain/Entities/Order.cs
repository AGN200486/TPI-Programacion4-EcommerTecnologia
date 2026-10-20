using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public double Total { get; set; }

    // Propiedad de navegación
    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>(); // lista que guarda todos los orderDetail de esa Orden

    // Constructor sin parametros requerido por Entity Framework Core
    public Order() { }
}