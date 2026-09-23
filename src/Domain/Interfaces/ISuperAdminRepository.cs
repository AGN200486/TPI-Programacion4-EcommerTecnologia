using Domain.Entities;

namespace Domain.Interfaces;

// Hereda de IAdminRepository (y por ende de IUserRepository)
// cualquier implementación de ISuperAdminRepository va a incluir automáticamente los métodos de Admin, los de User y los de IRepository<T>
public interface ISuperAdminRepository : IAdminRepository
{
    // Registra una nueva cuenta con rol y permisos de Administrador en el sistema
    Task CreateAdminAccountAsync(Admin newAdmin);
    // Permite habilitar o deshabilitar el acceso de un usuario al sistema mediante un valor booleano (true para activar, false para suspender)
    Task ToggleUserActiveStateAsync(int userId, bool isActive);
}