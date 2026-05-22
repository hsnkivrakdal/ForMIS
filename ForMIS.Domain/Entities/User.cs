namespace ForMIS.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string IdentityNumber { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string UserRole { get; set; } = null!;
}