using GreenPilot.Domain.Enums;

namespace GreenPilot.Core.DTOs.ResponseDtos.RunResponseDto;

public record RunShortResponseDto
{
  public Guid Id { get; init; }
  public Statuts Status { get; init; }
  public DateTime StartDate { get; init; }
  public DateTime PlantingDate { get; init; }
  public DateTime EndDate { get; init; }
  public int NumberOfPlants { get; init; }
}