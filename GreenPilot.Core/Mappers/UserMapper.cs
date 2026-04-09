using GreenPilot.Core.DTOs.RequestDtos.UserRequestDtos;
using GreenPilot.Domain.Entities;

namespace GreenPilot.Core.Mappers;

public static class UserMapper
{
  public static UserEntity ToEntity(this RegisterRequestDto dto, string hasherPassword)
  {
    return new UserEntity()
    {
      Id = Guid.NewGuid(),
      Pseudo = dto.Pseudo,
      Email = dto.Email,
      Password = hasherPassword
    };
  }
}