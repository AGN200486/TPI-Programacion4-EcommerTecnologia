namespace Application.Models;

public class PostOrderDetailRequest
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }
}