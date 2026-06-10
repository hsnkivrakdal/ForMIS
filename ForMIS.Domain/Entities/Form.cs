namespace ForMIS.Domain.Entities;

public class Form
{
    public int Id { get; set; }
    public int FormTypeId { get; set; }
    public int SemesterId { get; set; }
    public int  FormContentId { get; set; }
    public int FormStatusId { get; set; }
    public int StudentId { get; set; }
    public string StudentAdvisor { get; set; } = null!;
    public string StudentNumber { get; set; } = null!;
    public string StudentName { get; set; } = null!;
    public string StudentSurname { get; set; } = null!;
    public string StudentPhone { get; set; } = null!;
    public string StudentEmail { get; set; } = null!;
    public string StudentFaculty { get; set; } = null!;
    public decimal StudentGpa { get; set; }
    public string StudentDepartment { get; set; } = null!;
    public int NumOfSemesters { get; set; }
    public DateTime FormDate { get; set; }
    public string ScholarshipStatus { get; set; } = null!;
    public string StudentAddress { get; set; } = null!;
    public byte[]? StudentSignature { get; set; }
    public string? Subject { get; set; }
    public string? Body { get; set; }
    public string? RouteReason { get; set; }
}