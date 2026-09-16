namespace Domain.Entities;

public class Superadmin : User
{
    public Superadmin()
    {
        Role = "Superadmin";
    }
}