namespace GreenPilot.Domain.Entities;

public class HarvestEntity : BaseEntity
{
  public DateTime HarvestDate { get; set; }
  public int Weight { get; set; }
  public string? Remark { get; set; }
  public string? FinalAdvice { get; set; }
  
  public Guid RunId { get; set; }
  public required RunEntity Run { get; set; }
}