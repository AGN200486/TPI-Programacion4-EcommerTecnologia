namespace Domain.Entities;

public class OrderDetail
{
    public int Id { get; set; }
    public int OrderId { get; set; } // guarda el número ID de la orden en la base de datos (FK)
    public Order? Order { get; set; } // permite acceder a la información completa de la orden

    public int ProductId { get; set; } // guarda el ID del producto comprado (FK)
    public Product? Product { get; set; } // permite acceder a la información completa del producto

    public int Quantity { get; set; }
    public double UnitPrice { get; set; }

    // Constructor sin parametros requerido por Entity Framework Core
    public OrderDetail() { }
}