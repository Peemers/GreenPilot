using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using GreenPilot.Domain.Entities;
using GreenPilot.Domain.Enums;

namespace GreenPilot.Core.DTOs.ResponseDtos.RunResponseDto;

public record RunDetailsResponseDto
{
  public Guid Id { get; init; }
  public Statuts Status { get; init; }
  public DateTime StartDate { get; init; }
  public DateTime PlantingDate { get; init; }
  public DateTime EndSeedlingDate { get; init; }
  public DateTime FloweringBeginDate { get; init; }
  public DateTime EndDate { get; init; }
  public string Remark { get; init; } = string.Empty;
  public int NumberOfPlants { get; init; }

  public HarvestEntity? Harvest { get; init; }

  public required Guid UserId { get; init; }
}