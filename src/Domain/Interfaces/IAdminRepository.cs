using Domain.Entities;

namespace Domain.Interfaces;

// Hereda de IUserRepository porque Admin hereda de User
public interface IAdminRepository : IUserRepository
{
    // Actualiza la cantidad de unidades disponibles (stock) de un producto específico en el catálogo
    Task UpdateProductStockAsync(int productId, int newStock);
    // Modifica el estado actual de una orden
    Task ChangeOrderStatusAsync(int orderId, string status);
}