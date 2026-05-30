namespace ForMIS.Application.DTOs;

public class StudentDetailsDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string StudentNumber { get; set; } = null!;
    public int StandingId { get; set; }
    public string StandingName { get; set; } = null!;
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; } = null!;
    public int FacultyId { get; set; }
    public string FacultyName { get; set; } = null!;
    public int UserId { get; set; }
    public string IdentityNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string UserRole { get; set; } = null!;
    public int DepartmentMemberId { get; set; }
    public int DepartmentMemberUserId { get; set; }
    public string DepartmentMemberFirstName { get; set; } = null!;
    public string DepartmentMemberLastName { get; set; } = null!;
    public string DepartmentMemberTitle { get; set; } = null!;
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