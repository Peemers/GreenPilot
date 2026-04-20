using GreenPilot.Core.DTOs.RequestDtos.RunRequestDto;
using GreenPilot.Core.DTOs.ResponseDtos.RunResponseDto;
using GreenPilot.Domain.Entities;

namespace GreenPilot.Core.Interfaces.Services;

public interface IRunService
{
  Task RunStart(Guid id);
  Task StatusChange(Guid id);
  Task RunClose(Guid id);
  Task DeleteRun(Guid id);
  Task<IEnumerable<RunShortResponseDto>> GetAllRunsAsync();
  
  Task<RunDetailsResponseDto> UpdateRunAsync(RunUpdateRequestDto runUpdateRequest);
  Task<RunDetailsResponseDto> RunCreateAsync(RunCreateRequestDto runCreateRequest);
  Task<RunShortResponseDto> GetRunByIdAsync(Guid id);
  Task<RunPictureResponseDto> AddPicture(Guid id, RunPictureResponseDto dto);
  Task<RunDetailsResponseDto> GetTenLatest(RunShortResponseDto dto);
  
  
  
}