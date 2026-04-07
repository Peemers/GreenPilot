using GreenPilot.Domain.Entities;

namespace GreenPilot.Core.Interfaces.Repositories;

public interface IUserRepository : IBaseRepository<UserEntity>
{
  Task<UserEntity?> GetByEmailAsync(string email);
}