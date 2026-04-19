using System.ComponentModel.DataAnnotations;
using GreenPilot.Domain.Enums;

namespace GreenPilot.Core.DTOs.RequestDtos.RunRequestDto;

public record RunUpdateRequestDto(
  [Required]
  Statuts Status,
  DateTime PlantingDate,
  DateTime EndSeedlingDate,
  DateTime FloweringBeginDate,
  DateTime EndDate,
  string Remark
  );