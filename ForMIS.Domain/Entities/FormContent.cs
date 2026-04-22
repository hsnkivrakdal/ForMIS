namespace ForMIS.Domain.Entities;

public class FormContent
{
    public int Id { get; set; }
    public string FormContentDescription { get; set; } = null!;
    public int ContentPrecursorId { get; set; }
}