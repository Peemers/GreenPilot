using GreenPilot.Core.Interfaces.Repositories;
using GreenPilot.Domain.Entities;
using GreenPilot.Infrastructure.DataBase.Context;
using Microsoft.EntityFrameworkCore;

namespace GreenPilot.Infrastructure.Repositories;

public class UserRepository(GreenPilotDbContext context) : BaseRepository<UserEntity>(context), IUserRepository
{
  public async Task<UserEntity?> GetByEmailAsync(string email)
  {
    return await context.Users
      .FirstOrDefaultAsync(u => u.Email == email);
  }
}