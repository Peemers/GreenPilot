using GreenPilot.Domain.Entities;

namespace GreenPilot.Core.Interfaces.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
  Task<IEnumerable<T>> GetAllAsync();
  Task<T?> GetByIdAsync(Guid id);
  Task<T> AddAsync(T entity);
  Task<T> UpdateAsync(T entity);
  Task DeleteAsync(T entity);
}