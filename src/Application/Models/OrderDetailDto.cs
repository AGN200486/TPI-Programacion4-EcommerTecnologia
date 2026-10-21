using Domain.Entities;

namespace Application.Models;

public class OrderDetailDto
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }

    // Mapea una entidad OrderDetail a OrderDetailDto
    public static OrderDetailDto Create(OrderDetail detail)
    {
        return new OrderDetailDto
        {
            Id = detail.Id,
            OrderId = detail.OrderId,
            ProductId = detail.ProductId,
            Quantity = detail.Quantity,
            UnitPrice = detail.UnitPrice
        };
    }

    // Mapea una lista de detalles de orden
    public static List<OrderDetailDto> Create(IEnumerable<OrderDetail> details)
    {
        return details.Select(Create).ToList();
    }
}