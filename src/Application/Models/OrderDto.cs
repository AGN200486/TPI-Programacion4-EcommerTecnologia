using Domain.Entities;

namespace Application.Models;

public class OrderDto
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public double Total { get; set; }

    // Mapea una entidad Order a OrderDto
    public static OrderDto Create(Order order)
    {
        return new OrderDto
        {
            Id = order.Id,
            ClientId = order.ClientId,
            Total = order.Total
        };
    }

    // Mapea una lista de órdenes
    public static List<OrderDto> Create(IEnumerable<Order> orders)
    {
        return orders.Select(Create).ToList();
    }
}