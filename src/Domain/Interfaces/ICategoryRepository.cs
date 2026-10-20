using Domain.Entities;

namespace Domain.Interfaces;

// Hereda las operaciones CRUD basicas (GetById, GetAll, Add, Update, Delete) de IRepository<Category>
public interface ICategoryRepository : IRepository<Category>
{
}