using System.Diagnostics.CodeAnalysis;
using GreenPilot.Core.Interfaces.Repositories;
using GreenPilot.Domain.Entities;
using GreenPilot.Infrastructure.DataBase.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GreenPilot.Infrastructure.Repositories;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class BaseRepository<T>(GreenPilotDbContext context) : IBaseRepository<T> where T : BaseEntity
{
  private readonly DbSet<T> _entities = context.Set<T>();
  protected readonly GreenPilotDbContext context = context;

  public async Task<IEnumerable<T>> GetAllAsync()
  {
    return await _entities.AsNoTracking().ToListAsync();
  }

  public async Task<T?> GetByIdAsync(Guid id)
  {
    return await _entities.FindAsync(id);
  }

  public async Task<T> AddAsync(T entity)
  { 
    await _entities.AddAsync(entity);
    await context.SaveChangesAsync();
    return entity;
  }

  public async Task<T> UpdateAsync(T entity)
  {
    _entities.Update(entity);
    await context.SaveChangesAsync();
    return entity;
  }

  public async Task DeleteAsync(T entity)
  {
    T? entityToRemove = await _entities.FindAsync(entity.Id);
    if (entityToRemove != null)
    {
      _entities.Remove(entity);
      await context.SaveChangesAsync();
    }
  }
}