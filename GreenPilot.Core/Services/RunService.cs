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
  #region RunStartAsync

  public async Task<RunDetailsResponseDto> RunStartAsync(Guid id)
  {
    RunEntity? run = await runRepository.GetByIdAsync(id);
    if (run == null)
    {
      throw new KeyNotFoundException($"No run found with id {id}");
    }
    run.IsFinished = false;
    await runRepository.UpdateAsync(run);
    return run.ToDetailsResponseDto();
  }

  #endregion

  #region StatusChangeAsync

  // public async Task StatusChangeAsync(Guid id)
  // {
  //   RunEntity? run = await runRepository.GetByIdAsync(id);
  //   if (run == null)
  //   {
  //     throw new KeyNotFoundException($"No run found with id {id}");
  //   }
  //
  //   if (run.IsFinished)
  //   {
  //     throw new Exception("The run is already finished");
  //   }
  // }

  #endregion

  #region RunCloseAsync

  public async Task RunCloseAsync(Guid id)
  {
    RunEntity? run = await runRepository.GetByIdAsync(id);
    if (run == null)
    {
      throw new KeyNotFoundException($"No run found with id {id}");
    }

    if (run.IsFinished)
    {
      throw new Exception("The run is already finished");
    }
    run.IsFinished = true;
    await runRepository.UpdateAsync(run);
  }

  #endregion

  #region DeleteRunAsync

  public async Task DeleteRunAsync(Guid id)
  {
    RunEntity? run = await runRepository.GetByIdAsync(id);
    if (run == null)
    {
      throw new KeyNotFoundException($"No run found with id {id}");
    }
    await runRepository.DeleteAsync(run);
  }

  #endregion

  #region GetAllRunsAsync

  public async Task<IEnumerable<RunShortResponseDto>> GetAllRunsAsync()
  {
    IEnumerable<RunEntity> runs = await runRepository.GetAllAsync();
    return runs.Select(r => r.ToShortResponseDto());
  }

  #endregion

  #region GetByUserIdAsync

  public async Task<IEnumerable<RunShortResponseDto>> GetByUserIdAsync(Guid userId)
  {
    IEnumerable<RunEntity> runs = await runRepository.GetByUserIdAsync(userId);
    return runs.Select(r => r.ToShortResponseDto());
  }

  #endregion

  #region GetByStatusAsync

  public async Task<IEnumerable<RunShortResponseDto>> GetByStatusAsync(Statuts statuts)
  {
    IEnumerable<RunEntity> runs = await runRepository.GetByStatusAsync(statuts);
    return runs.Select(r => r.ToShortResponseDto());
  }

  #endregion

  #region UpdateRunAsync

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

  #endregion

  #region CreateRunAsync

  public async Task<RunDetailsResponseDto> CreateRunAsync(RunCreateRequestDto runCreateRequest, Guid userId)
  {
    RunEntity newRun = runCreateRequest.ToRunEntity(userId);
    RunEntity result = await runRepository.AddAsync(newRun);
    return result.ToDetailsResponseDto();
  }

  #endregion

  #region GetRunByIdAsync

  public async Task<RunDetailsResponseDto> GetRunByIdAsync(Guid id)
  {
    RunEntity? run = await runRepository.GetByIdAsync(id);
    if (run == null)
    {
      throw new KeyNotFoundException($"No run found with id {id}");
    }
    return run.ToDetailsResponseDto();
  }

  #endregion

  #region AddPictureAsync

  public async Task<RunDetailsResponseDto> AddPictureAsync(Guid id, RunPictureRequestDto dto)
  {
    RunEntity? run = await runRepository.GetByIdAsync(id);
    if (run == null)
    {
      throw new KeyNotFoundException($"No run found with id {id}");
    }
    run.ToEntityUpdatePics(dto);
    await runRepository.UpdateAsync(run);
    
    return run.ToDetailsResponseDto();
  }

  #endregion

  #region GetTenLatestAsync

  public async Task<IEnumerable<RunShortResponseDto>> GetTenLatestAsync(Guid userId)
  {
    IEnumerable<RunEntity> runs = await runRepository.GetTenLatestAsync();
    return runs.Select(r => r.ToShortResponseDto());
  }
  #endregion
}