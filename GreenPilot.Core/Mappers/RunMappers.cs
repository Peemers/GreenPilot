using GreenPilot.Core.DTOs.RequestDtos.RunRequestDto;
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
      UserId = runEntity.UserId,
      IsFinished =  runEntity.IsFinished,
    };
  }

  public static RunShortResponseDto ToShortResponseDto(this RunEntity runEntity)
  {
    return new RunShortResponseDto()
    {
      Id = runEntity.Id,
      Status = runEntity.Statut,
      StartDate = runEntity.StartDate,
      PlantingDate = runEntity.PlantingDate,
      EndDate = runEntity.EndDate,
      NumberOfPlants = runEntity.NumberOfPlants,
      IsFinished =  runEntity.IsFinished,
    };
  }

  public static RunEntity ToRunEntity(this RunCreateRequestDto dto, Guid userId)
  {
    return new RunEntity()
    {
      Id =  dto.Id,
      Statut = dto.Statut,
      StartDate = DateTime.UtcNow,
      Remark =  dto.Remark,
      NumberOfPlants = dto.NumberOfPlants,
      IsFinished = false,
      UserId = userId,
      User = null!
    };
  }

  public static void UpdateEntity(this RunEntity runEntity, RunUpdateRequestDto dto)
  {
    runEntity.Statut = dto.Status;
    runEntity.PlantingDate = dto.PlantingDate;
    runEntity.EndSeedlingDate = dto.EndSeedlingDate;
    runEntity.FloweringBeginDate = dto.FloweringBeginDate;
    runEntity.EndDate = dto.EndDate;
    runEntity.Remark = dto.Remark;
    runEntity.IsFinished = dto.IsFinished;
    runEntity.UpdateDate = DateTime.UtcNow;
  }

  public static void ToEntityUpdatePics(this RunEntity runEntity, RunPictureRequestDto dto)
  {
    runEntity.UrlPics = dto.UrlPics;
  }
}