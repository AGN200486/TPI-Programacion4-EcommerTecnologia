using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    // Atributo privado y de solo lectura para almacenar la instancia del DbContext.
    // Esta variable es nuestro canal directo de comunicación con la base de datos de SQLite.
    private readonly ApplicationContext _context;

    // CONSTRUCTOR: Aplica el patrón de Inyección de Dependencias.
    // .NET se encarga de crear y pasarle automáticamente la instancia de 'ApplicationContext' a este repositorio
    // cuando alguien pida un 'IProductRepository'.
    public ProductRepository(ApplicationContext context)
    {
        _context = context; // Guardamos la instancia recibida para usarla en los métodos de abajo.
    }

    // Obtener todos los Productos
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    // Obtener un producto por su ID
    public async Task<Product?> GetByIdAsync(int id)
    {
        // Si no lo encuentra, devuelve 'null'
        return await _context.Products.FindAsync(id);
    }

    // Alta de Producto
    public async Task<Product> AddAsync(Product product)
    {
        // AddAsync registra el nuevo objeto en la memoria local de Entity Framework
        await _context.Products.AddAsync(product);

        // SaveChangesAsync es la instrucción que impacta los cambios en SQLite
        await _context.SaveChangesAsync();

        return product;
    }

    // Modificacion de Producto
    public async Task UpdateAsync(Product product)
    {
        // Update marca las propiedades del objeto como modificadas dentro del rastreador de EF
        _context.Products.Update(product);

        // Guarda los cambios ejecutando el "UPDATE" en la base de datos
        await _context.SaveChangesAsync();
    }

    // Baja de un Producto
    public async Task DeleteAsync(int id)
    {
        // Primero buscamos si el producto realmente existe en la base de datos
        var product = await _context.Products.FindAsync(id);

        if (product != null)
        {
            // Remove marca el registro para ser eliminado
            _context.Products.Remove(product);

            // Ejecuta el "DELETE FROM Products WHERE Id = id" en la base de datos
            await _context.SaveChangesAsync();
        }
    }
}