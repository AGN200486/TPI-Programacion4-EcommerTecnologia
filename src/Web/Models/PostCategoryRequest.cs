namespace Application.Models;

// Representa la información que el cliente envía para crear una categoría
public record PostCategoryRequest(
    string Name
);