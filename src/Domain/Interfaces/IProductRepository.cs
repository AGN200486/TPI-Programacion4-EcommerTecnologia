using Domain.Entities;

namespace Domain.Interfaces;

public interface IProductRepository
{
    // Consultas (Get All / Get By Id)
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);

    // Alta
    Task<Product> AddAsync(Product product);

    // Modificación
    Task UpdateAsync(Product product);

    // Baja
    Task DeleteAsync(int id);
}