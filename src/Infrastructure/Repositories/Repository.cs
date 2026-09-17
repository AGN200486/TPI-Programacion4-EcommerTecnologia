using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

// base generica que implementa el contrato IRepository<T>
public class Repository<T> : IRepository<T> where T : class // 'where T : class' restringe el tipo T para que siempre sea una clase
{
    // Inyeccion del contexto de base de datos de Entity Framework
    protected readonly ApplicationContext _context; // Usamos 'protected' para que las clases hijas puedan acceder a ellos
    
    // DbSet representa la tabla especifica correspondiente a la entidad T
    protected readonly DbSet<T> _dbSet;

    public Repository(ApplicationContext context)
    {
        _context = context;
        // Obtenemos el conjunto de datos correspondiente a la entidad T desde el DbContext
        _dbSet = _context.Set<T>();
    }

    // Obtiene una entidad por su clave primaria (Id) de manera asincronica
    public async Task<T?> GetByIdAsync(int id) // Retorna 'T?' porque la entidad puede no existir en la base de datos (retornando null)
    {
        return await _dbSet.FindAsync(id);
    }

    // Obtiene el listado completo de registros de la tabla correspondiente
    public async Task<IReadOnlyList<T>> GetAllAsync() // Retorna IReadOnlyList<T> para exponer una lista de solo lectura
    {
        return await _dbSet.ToListAsync();
    }

    // Agrega una nueva entidad al contexto y persiste los cambios en la base de datos
    public async Task<T> AddAsync(T entity)
    {
        // Registra la nueva entidad en la memoria de Entity Framework
        await _dbSet.AddAsync(entity);
        
        // Impacta los cambios en la base de datos SQLite
        await _context.SaveChangesAsync();
        
        return entity;
    }

    // Actualiza el estado de una entidad existente y guarda los cambios en SQLite
    public async Task UpdateAsync(T entity)
    {
        // Marca las propiedades del objeto como modificadas dentro del ChangeTracker de EF
        _dbSet.Update(entity);
        
        // Ejecuta el UPDATE en la base de datos
        await _context.SaveChangesAsync();
    }

    // Elimina un registro buscando primero si existe por su identificador
    public async Task DeleteAsync(int id)
    {
        // Buscamos el registro en la base de datos
        var entity = await GetByIdAsync(id);
        
        // Si la entidad existe, la marcamos para eliminacion y guardamos cambios
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}