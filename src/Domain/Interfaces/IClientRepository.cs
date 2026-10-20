using Domain.Entities;

namespace Domain.Interfaces;

// Hereda de IUserRepository porque Client hereda de User
public interface IClientRepository : IUserRepository
{
    // Obtiene el historial completo de órdenes realizadas por un cliente específico a través de su ID.
    Task<IReadOnlyList<Order>> GetClientOrdersAsync(int clientId);
}