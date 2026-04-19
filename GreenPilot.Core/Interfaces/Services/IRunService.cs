using GreenPilot.Core.DTOs.RequestDtos.RunRequestDto;
using GreenPilot.Core.DTOs.ResponseDtos.RunResponseDto;

namespace GreenPilot.Core.Interfaces.Services;

public interface IRunService
{
  Task RunStart(Guid id);
  Task StatusChange(Guid id);
  Task RunClose(Guid id);
  Task<RunPictureResponseDto> AddPicture(Guid id, RunPictureResponseDto dto);
  Task<RunDetailsResponseDto> GetTenLatest(RunShortResponseDto dto);
  Task<RunDetailsResponseDto> CreateRunAsync(RunCreateRequestDto dto);
  Task<RunDetailsResponseDto> UpdateRunAsync(Guid id, RunUpdateRequestDto dto);
  
}