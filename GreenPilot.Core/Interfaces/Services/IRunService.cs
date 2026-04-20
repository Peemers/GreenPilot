using GreenPilot.Core.DTOs.RequestDtos.RunRequestDto;
using GreenPilot.Core.DTOs.ResponseDtos.RunResponseDto;
using GreenPilot.Domain.Entities;

namespace GreenPilot.Core.Interfaces.Services;

public interface IRunService : IBaseService<RunEntity>
{
  Task RunStart(Guid id);
  Task StatusChange(Guid id);
  Task RunClose(Guid id);
  Task<RunPictureResponseDto> AddPicture(Guid id, RunPictureResponseDto dto);
  Task<RunDetailsResponseDto> GetTenLatest(RunShortResponseDto dto);
  
  
  
}