using GreenPilot.Domain.Entities;

namespace GreenPilot.Core.Interfaces.Repositories;

public interface IRunRepository : IBaseRepository<RunEntity>
{
  Task<IEnumerable<RunEntity>> GetByUserIdAsync(Guid userId);
  Task<RunEntity?> GetWithAllDetails(Guid runId);
}
