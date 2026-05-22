namespace ForMIS.Application.DTOs;

public class StudentDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string StudentNumber { get; set; } = null!;
    public int StandingId { get; set; }
    public int DepartmentId { get; set; }
    public int UserId { get; set; }
    public int DepartmentMemberId { get; set; }
    public decimal OverallCompletedEcts { get; set; }
    public decimal ProgramCompletedEcts { get; set; }
    public decimal OverallGpa { get; set; }
    public decimal ProgramGpa { get; set; }
    public int NumOfSemesters { get; set; }
    public string Status { get; set; } = null!;
    public string Scholarship { get; set; } = null!;
    public string Address { get; set; } = null!;
    public byte[] Signature { get; set; } = null!;
}