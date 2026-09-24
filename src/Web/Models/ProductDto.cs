using Domain.Entities;

namespace Application.Models;

// DTO para estructurar la respuesta enviada al cliente HTTP
public record ProductDto(
    int Id,
    string Name,
    string Description,
    decimal Price,
    int Stock,
    string Category,
    string Image,
    bool Active
)
{
    // Transforma una entidad de dominio en el DTO de respuesta
    public static ProductDto Create(Product entity)
    {
        return new ProductDto(
            entity.Id,
            entity.Name,
            entity.Description,
            entity.Price,
            entity.Stock,
            entity.Category,
            entity.Image,
            entity.Active
        );
    }

    // Sobrecarga para mapear una lista de entidades a una lista de DTOs
    public static List<ProductDto> Create(IEnumerable<Product> entities)
    {
        var listDto = new List<ProductDto>();
        foreach (var entity in entities)
        {
            listDto.Add(Create(entity));
        }

        return listDto;
    }
}