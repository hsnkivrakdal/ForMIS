namespace ForMIS.Domain.Entities;

public class FormIlisikKesmeDetails
{
    public int Id { get; set; }
    public int FormId { get; set; }
    public string Faculty { get; set; } = null!;
    public string? Scholarship { get; set; }
    public string Address { get; set; } = null!;
    public bool ReasonTransfer { get; set; }
    public string? TransferUniversity { get; set; }
    public bool ReasonSFL { get; set; }
    public bool ReasonFinancial { get; set; }
    public bool ReasonLYS { get; set; }
    public string? LYSUniversity { get; set; }
    public bool ReasonDissatisfaction { get; set; }
    public string? DissatisfactionDetails { get; set; }
    public bool ReasonOther { get; set; }
    public string? OtherDetails { get; set; }
}