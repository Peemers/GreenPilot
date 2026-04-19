using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using GreenPilot.Domain.Entities;
using GreenPilot.Domain.Enums;

namespace GreenPilot.Core.DTOs.ResponseDtos.RunResponseDto;

public record RunDetailsDto(
  Guid Id,
  [Required]
  Statuts Status,
  [Required]
  DateTime StartDate,
  DateTime PlantingDate,
  DateTime EndSeedlingDate,
  DateTime FloweringBeginDate,
  DateTime EndDate,
  [MaxLength(250)]
  string Remark,
  [Required]
  int PlantsNumber,
  
  HarvestEntity? Harvest,
  UserEntity UserId
  
  );
