namespace ForMIS.Domain.Entities;

public class FormEkSinav44cCourses
{
    public int Id { get; set; }
    public int FormId { get; set; }
    public int SortOrder { get; set; }
    public string CourseCode { get; set; } = null!;
    public string TakenBefore { get; set; } = null!;
}
