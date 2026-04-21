using System.ComponentModel.DataAnnotations;
using GreenPilot.Domain.Enums;

namespace GreenPilot.Core.DTOs.RequestDtos.RunRequestDto;

public record RunUpdateRequestDto
{
  public Statuts Status { get; init; } 
  public DateTime PlantingDate { get; init; }

  public DateTime EndSeedlingDate { get; init; }
  public DateTime FloweringBeginDate { get; init; }
  public DateTime EndDate { get; init; }
  public string Remark { get; init; } = string.Empty;
  public bool IsFinished { get; init; }
}