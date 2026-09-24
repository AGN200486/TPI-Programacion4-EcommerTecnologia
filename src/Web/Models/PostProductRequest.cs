namespace Application.Models;

// representa la informacion que el cliente envia para crear un producto
public record PostProductRequest(
    string Name,
    string Description,
    decimal Price,
    int Stock,
    string Category,
    string Image
);