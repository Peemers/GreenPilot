using GreenPilot.Domain.Enums;

namespace GreenPilot.Domain.Entities;

public class RunEntity : BaseEntity
{
  public required Statuts Statut { get; set; }
  public required DateTime StartDate { get; set; }
  public DateTime PlantingDate { get; set; }
  public DateTime EndSeedlingDate { get; set; }
  public DateTime FloweringBeginDate {get; set; }
  public DateTime EndDate {get; set; }
  public string Remark {get; set; } = string.Empty;
  public string UrlPics {get; set; } = string.Empty;
  public DateTime UpdateDate {get; set; }
  public required int NumberOfPlants {get; set; }
  
  
  
  public Guid UserId { get; set; } //nav
  
  public HarvestEntity? Harvest { get; set; }
  public required UserEntity User { get; set; } //nav
}