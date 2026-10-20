using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class User
{
    public int Id { get; set; }

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public bool Active { get; set; } = true;

    // Constructor sin parametros necesario para Entity Framework Core
    public User() { }
}