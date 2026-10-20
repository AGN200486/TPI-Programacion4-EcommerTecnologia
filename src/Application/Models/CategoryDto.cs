using Domain.Entities;

namespace Application.Models;

public record CategoryDto(
    int Id,
    string Name
)
{
    // Transforma una entidad de dominio en el DTO de respuesta
    public static CategoryDto Create(Category entity)
    {
        return new CategoryDto(
            entity.Id,
            entity.Name
        );
    }

    // Sobrecarga para mapear una lista de entidades a una lista de DTOs
    public static List<CategoryDto> Create(IEnumerable<Category> entities)
    {
        var listDto = new List<CategoryDto>();
        foreach (var entity in entities)
        {
            listDto.Add(Create(entity));
        }

        return listDto;
    }
}