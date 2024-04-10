using Domain.Enums.RolesEnum;

namespace Domain.Entities;

public class Users
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Roles Role { get; set; }
    public string RefreshToken { get; set; } = string.Empty;
    public DateTimeOffset TokenCreated { get; set; }
    public DateTimeOffset TokenExpires { get; set; }

    public Users() { }

    public Users(string name, string surname, string email, string password, Roles role)
    {
        Name = name;
        Surname = surname;
        Email = email;
        Password = password;
        Role = role;
    }
}