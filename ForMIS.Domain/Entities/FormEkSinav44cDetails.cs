namespace ForMIS.Domain.Entities;

public class FormEkSinav44cDetails
{
    public int Id { get; set; }
    public int FormId { get; set; }
    public string YearStart { get; set; } = null!;
    public string YearEnd { get; set; } = null!;
    public string AcademicTerm { get; set; } = null!;
}