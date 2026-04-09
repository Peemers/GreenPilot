using GreenPilot.Domain.Entities;

namespace GreenPilot.Core.Interfaces.Tools;

public interface IJwtService
{
  string GenererToken(UserEntity user);
}