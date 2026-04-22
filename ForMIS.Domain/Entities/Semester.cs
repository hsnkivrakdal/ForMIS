namespace ForMIS.Domain.Entities;

public class Semester
{
    public int Id { get; set; }
    public string SemesterName { get; set; } = null!;
    public bool IsActive { get; set; }
    public DateOnly SemesterStartDate { get; set; }
    public DateOnly SemesterEndDate { get; set; }
}