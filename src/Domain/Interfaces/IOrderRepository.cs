using Domain.Entities;

namespace Domain.Interfaces;

// Hereda las operaciones CRUD basicas (GetById, GetAll, Add, Update, Delete) de IRepository<Order>
public interface IOrderRepository : IRepository<Order>
{
    // Metodo especifico para obtener ordenes incluyendo la informacion del Cliente y sus Productos
}