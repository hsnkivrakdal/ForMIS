namespace ForMIS.Domain.Entities;

public class FormMazeretSinaviFinalDetails
{
    public int Id { get; set; }
    public int FormId { get; set; }
    public string Faculty { get; set; } = null!;
    public string ExcuseDates { get; set; } = null!;
    public string CourseCodesAndSections { get; set; } = null!;
    public string ExcuseDetails { get; set; } = null!;
    public string? AttachedDocuments { get; set; }
    public bool HasHealthReport { get; set; }
    public string? HealthReportInstitution { get; set; }
    public DateTime? HealthReportDate { get; set; }
    public string? HealthReportDuration { get; set; }
}
