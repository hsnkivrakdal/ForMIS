namespace ForMIS.Application.DTOs;

public class FormContentDto
{
    public int Id { get; set; }
    public string FormContentDescription { get; set; } = null!;
    public int ContentPrecursorId { get; set; }
}