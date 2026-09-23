namespace Domain.Interfaces;

public interface IRepository<T> where T : class
{   
    // Consultas (Get By Id / Get All)
    Task<T?> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> GetAllAsync();
    // Alta
    Task<T> AddAsync(T entity);
    // Modificacion
    Task UpdateAsync(T entity);
    // Baja
    Task DeleteAsync(int id);
}