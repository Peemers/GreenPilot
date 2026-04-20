using GreenPilot.Core.DTOs.ResponseDtos.RunResponseDto;
using GreenPilot.Domain.Entities;
using GreenPilot.Domain.Enums;

namespace GreenPilot.Core.Mappers;

public static class RunMappers
{
  public static RunDetailsResponseDto ToDetailsResponseDto(this RunEntity runEntity)
  {
    return new RunDetailsResponseDto()
    {
      Id = runEntity.Id,
      Status = runEntity.Statut,
      StartDate = runEntity.StartDate,
      PlantingDate = runEntity.PlantingDate,
      EndSeedlingDate = runEntity.EndSeedlingDate,
      FloweringBeginDate = runEntity.FloweringBeginDate,
      EndDate = runEntity.EndDate,
      Remark = runEntity.Remark,
      NumberOfPlants = runEntity.NumberOfPlants,
      UserId = runEntity.UserId
    };
  }
}