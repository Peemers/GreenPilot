using GreenPilot.Core.DTOs.ResponseDtos.RunResponseDto;
using GreenPilot.Domain.Entities;
using GreenPilot.Domain.Enums;

namespace GreenPilot.Core.Interfaces.Repositories;

public interface IRunRepository : IBaseRepository<RunEntity>
{
  Task<IEnumerable<RunEntity>> GetByUserIdAsync(Guid userId);
  Task<RunEntity?> GetWithAllDetails(Guid runId);

  Task<IEnumerable<RunEntity>> GetByStatusAsync(Statuts statuts);

}
