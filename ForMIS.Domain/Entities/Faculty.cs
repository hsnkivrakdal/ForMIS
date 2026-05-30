namespace ForMIS.Domain.Entities;

public class Faculty
{
    public int Id { get; set; }
    public string FacultyName { get; set; } = null!;
    public int UniversityId { get; set; }
}