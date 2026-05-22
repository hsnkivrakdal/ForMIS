namespace ForMIS.Domain.Entities;

public class FormType
{
    public int Id { get; set; }
    public string TypeName { get; set; } = null!;
    public string FormLanguage { get; set; } = null!;
    public int DepartmentId { get; set; }
    public string LayoutKey { get; set; } = null!;
}