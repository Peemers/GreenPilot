using GreenPilot.Core.DTOs.RequestDtos.RunRequestDto;
using GreenPilot.Core.DTOs.ResponseDtos.RunResponseDto;
using GreenPilot.Domain.Entities;
using GreenPilot.Domain.Enums;

namespace GreenPilot.Core.Interfaces.Services;

public interface IRunService
{
  Task RunStartAsync(Guid id);
  Task StatusChangeAsync(Guid id);
  Task RunCloseAsync(Guid id);
  Task DeleteRunAsync(Guid id);
  Task<IEnumerable<RunShortResponseDto>> GetAllRunsAsync();
  Task<IEnumerable<RunShortResponseDto>> GetByUserIdAsync(Guid userId);
  Task<IEnumerable<RunShortResponseDto>> GetByStatusAsync(Statuts statuts);
  Task<RunDetailsResponseDto> UpdateRunAsync(RunUpdateRequestDto runUpdateRequest, Guid id);
  Task<RunDetailsResponseDto> CreateRunAsync(RunCreateRequestDto runCreateRequest, Guid userId);
  Task<RunDetailsResponseDto> GetRunByIdAsync(Guid id);
  Task<RunDetailsResponseDto> AddPictureAsync(Guid id, RunPictureRequestDto dto);
  Task<IEnumerable<RunShortResponseDto>> GetTenLatestAsync(Guid userId);
  
  
  
}