namespace ForMIS.Application.DTOs;

public class FormEkSinav44cCoursesDto
{
    public int Id { get; set; }
    public int FormId { get; set; }
    public int SortOrder { get; set; }
    public string CourseCode { get; set; } = null!;
    public string TakenBefore { get; set; } = null!;
}