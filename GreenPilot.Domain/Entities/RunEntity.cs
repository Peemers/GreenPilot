using GreenPilot.Domain.Enums;

namespace GreenPilot.Domain.Entities;

public class RunEntity : BaseEntity
{
  public required Statuts Statut { get; set; }
  public required DateTime StartTime { get; set; }
  public DateTime PlantingDate { get; set; }
  public DateTime EndSeedlingDate { get; set; }
  public DateTime FloweringBeginDate {get; set; }
  public DateTime EndDate {get; set; }
  public string Remark {get; set; } = string.Empty;
  public string UrlPics {get; set; } = string.Empty;
  public DateTime UpdateDate {get; set; }
  public int PlantsNumber {get; set; }
}