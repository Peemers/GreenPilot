using GreenPilot.Domain.Enums;

namespace GreenPilot.Core.DTOs.ResponseDtos.RunResponseDto;

public record RunShortResponseDto(
  Guid Id,
  Statuts Status,
  DateTime StartDate,
  DateTime PlantingDate,
  DateTime EndDate,
  int NumberOfPlants
  );