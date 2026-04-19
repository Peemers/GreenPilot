using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using GreenPilot.Domain.Entities;
using GreenPilot.Domain.Enums;

namespace GreenPilot.Core.DTOs.ResponseDtos.RunResponseDto;

public record RunDetailsResponseDto(
  Guid Id,
  Statuts Status,
  DateTime StartDate,
  DateTime PlantingDate,
  DateTime EndSeedlingDate,
  DateTime FloweringBeginDate,
  DateTime EndDate,
  string Remark,
  int PlantsNumber,
  
  HarvestEntity? Harvest,
  UserEntity UserId
  
  );
