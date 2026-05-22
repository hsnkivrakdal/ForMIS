namespace ForMIS.Domain.Entities;

public class DepartmentMember
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string MemberTitle { get; set; } = null!;
}