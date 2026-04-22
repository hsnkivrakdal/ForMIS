namespace ForMIS.Domain.Entities;

public class FormContentPrecursor
{
    public int Id { get; set; }
    public string FormContentPrecursors { get; set; } = null!;
    public int FormTypeId { get; set; }
    public string FormContentValue { get; set; } = null!;
    public bool IsChecked  { get; set; }
}