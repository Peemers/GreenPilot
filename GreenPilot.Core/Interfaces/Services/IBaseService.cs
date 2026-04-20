using GreenPilot.Core.DTOs.RequestDtos.RunRequestDto;
using GreenPilot.Domain.Entities;

namespace GreenPilot.Core.Interfaces.Services;

public interface IBaseService<T> where T : BaseEntity
{
  Task<T> CreateAsync(T entity);
  Task<T> UpdateAsync(T entity);
  Task<T?>  GetByIdAsync(Guid id);
  Task<IEnumerable<T>> GetAllAsync();
  Task DeleteAsync(Guid id);
  
}