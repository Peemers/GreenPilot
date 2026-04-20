using GreenPilot.Core.Interfaces.Repositories;
using GreenPilot.Core.Interfaces.Services;
using GreenPilot.Domain.Entities;

namespace GreenPilot.Core.Services;

public class BaseService<T>(
  IBaseRepository<T> baseRepository) : IBaseService<T> where T : BaseEntity
{
  public Task<T> CreateAsync(T entity)
  {
    throw new NotImplementedException();
  }

  public Task<T> UpdateAsync(T entity)
  {
    throw new NotImplementedException();
  }

  public Task<T?> GetByIdAsync(Guid id)
  {
    throw new NotImplementedException();
  }

  public async Task<IEnumerable<T>> GetAllAsync()
  {
    IEnumerable<T> entities = await baseRepository.GetAllAsync();
    return entities;
  }

  public async Task DeleteAsync(Guid id)
  {
    T? entity = await baseRepository.GetByIdAsync(id);
    if (entity == null)
    {
      throw new KeyNotFoundException("Entity not found");
    }
    
    await baseRepository.DeleteAsync(entity);
  }
}