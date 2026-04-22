namespace ForMIS.Application.DTOs;

public class UserDto
{
    public int Id { get; set; }
    public string IdentityNumber { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string StudentNumber { get; set; } = null!;
    public int StandingId { get; set; }
    public int DepartmentId { get; set; }
    public decimal OverallCompletedEcts { get; set; }
    public decimal ProgramCompletedEcts { get; set; }
    public decimal OverallGpa { get; set; }
    public decimal ProgramGpa { get; set; }
    public int NumOfSemesters { get; set; }
    public string Status { get; set; } = null!;
    public byte[] Signature { get; set; } = null!;
}