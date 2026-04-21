using GreenPilot.Core.DTOs.RequestDtos.RunRequestDto;
using GreenPilot.Core.DTOs.ResponseDtos.RunResponseDto;
using GreenPilot.Core.Interfaces.Repositories;
using GreenPilot.Core.Interfaces.Services;
using GreenPilot.Core.Mappers;
using GreenPilot.Domain.Entities;
using GreenPilot.Domain.Enums;
using Microsoft.Extensions.Logging;

namespace GreenPilot.Core.Services;

public class RunService(
  IUserRepository userRepository,
  IRunRepository runRepository,
  ILogger<RunService> logger) : IRunService
{
  public Task RunStartAsync(Guid id)
  {
    throw new NotImplementedException();
  }

  public Task StatusChangeAsync(Guid id)
  {
    throw new NotImplementedException();
  }

  public Task RunCloseAsync(Guid id)
  {
    throw new NotImplementedException();
  }

  public async Task DeleteRunAsync(Guid id)
  {
    RunEntity? run = await runRepository.GetByIdAsync(id);
    if (run == null)
    {
      throw new KeyNotFoundException($"No run found with id {id}");
    }
    await runRepository.DeleteAsync(run);
  }

  public async Task<IEnumerable<RunShortResponseDto>> GetAllRunsAsync()
  {
    IEnumerable<RunEntity> runs = await runRepository.GetAllAsync();
    return runs.Select(r => r.ToShortResponseDto());
  }

  public async Task<IEnumerable<RunShortResponseDto>> GetByUserIdAsync(Guid userId)
  {
    IEnumerable<RunEntity> runs = await runRepository.GetByUserIdAsync(userId);
    return runs.Select(r => r.ToShortResponseDto());
  }

  public async Task<IEnumerable<RunShortResponseDto>> GetByStatusAsync(Statuts statuts)
  {
    IEnumerable<RunEntity> runs = await runRepository.GetByStatusAsync(statuts);
    return runs.Select(r => r.ToShortResponseDto());
  }

  public async Task<RunDetailsResponseDto> UpdateRunAsync(RunUpdateRequestDto runUpdateRequest, Guid id)
  {
    RunEntity? run = await runRepository.GetByIdAsync(id);
    if (run == null)
    {
      throw new KeyNotFoundException($"No run found with id {id}");
    }
    run.UpdateEntity(runUpdateRequest);
    await runRepository.UpdateAsync(run);
    return run.ToDetailsResponseDto();
  }

  public async Task<RunDetailsResponseDto> CreateRunAsync(RunCreateRequestDto runCreateRequest, Guid userId)
  {
    RunEntity newRun = runCreateRequest.ToRunEntity(userId);
    RunEntity result = await runRepository.AddAsync(newRun);
    return result.ToDetailsResponseDto();
  }
  public Task<RunDetailsResponseDto> GetRunByIdAsync(Guid id)
  {
    throw new NotImplementedException();
  }

  public Task<RunPictureResponseDto> AddPictureAsync(Guid id, RunPictureResponseDto dto)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<RunShortResponseDto>> GetTenLatestAsync(Guid userId)
  {
    throw new NotImplementedException();
  }
}