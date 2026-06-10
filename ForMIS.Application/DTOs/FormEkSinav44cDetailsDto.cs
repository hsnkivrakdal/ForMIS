namespace ForMIS.Application.DTOs;

public class FormEkSinav44cDetailsDto
{
    public int Id { get; set; }
    public int FormId { get; set; }
    public string YearStart { get; set; } = null!;
    public string YearEnd { get; set; } = null!;
    public string AcademicTerm { get; set; } = null!;
}