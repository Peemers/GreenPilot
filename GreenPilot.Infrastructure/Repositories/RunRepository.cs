using GreenPilot.Core.Interfaces.Repositories;
using GreenPilot.Domain.Entities;
using GreenPilot.Domain.Enums;
using GreenPilot.Infrastructure.DataBase.Context;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;

namespace GreenPilot.Infrastructure.Repositories;

public class RunRepository(GreenPilotDbContext context) : BaseRepository<RunEntity>(context), IRunRepository
{
  public async Task<IEnumerable<RunEntity>> GetByUserIdAsync(Guid userId)
  {
    return await context.Runs
      .Where(r => r.UserId == userId)
      .OrderByDescending(r => r.StartDate)
      .ToListAsync();
  }

  public async Task<RunEntity?> GetWithAllDetails(Guid id)
  {
    return await context.Runs
      .Include(r => r.Harvest)
      .Include(r => r.User)
      .FirstOrDefaultAsync(r => r.Id == id);
  }

  public async Task<IEnumerable<RunEntity>> GetByStatusAsync(Statuts statuts)
  {
    return await context.Runs
      .Where(r => r.Statut == statuts)
      .ToListAsync();
  }
  
}