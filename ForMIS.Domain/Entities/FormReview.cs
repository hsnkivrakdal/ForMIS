namespace ForMIS.Domain.Entities;

public class FormReview
{
    public int Id { get; set; }
    public int FormId { get; set; }
    public int DepartmentMemberId { get; set; }
    public string Opinion { get; set; } = null!;
    public byte[] Signature { get; set; } = null!;
    public string Decision { get; set; } = null!;
    public DateTime ReviewedAt { get; set; }
}