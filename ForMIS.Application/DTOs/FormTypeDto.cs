namespace ForMIS.Application.DTOs;

public class FormTypeDto
{
    public int Id { get; set; }
    public string TypeName { get; set; } = null!;
    public string FormLanguage { get; set; } = null!;
    public int DepartmentId { get; set; }
}