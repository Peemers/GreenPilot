using GreenPilot.Core.DTOs.RequestDtos.UserRequestDtos;
using GreenPilot.Core.DTOs.ResponseDtos;
using GreenPilot.Core.Interfaces.Repositories;
using GreenPilot.Core.Interfaces.Services;
using GreenPilot.Domain.Entities;
using GreenPilot.Domain.Enums;

namespace GreenPilot.Core.Services;

public class AuthService(IUserRepository userRepository) : IAuthService
{
  public async Task<AuthResponseDto> LoginAsync(LoginRequestDto dto)
  {
    UserEntity? users = await userRepository.GetByUsernameAsync(dto.Pseudo);
    if (users is null)
    {
      throw new KeyNotFoundException($"Invalid UserName, Email or Password");
    }

    return new AuthResponseDto
    {
      Pseudo = dto.Pseudo,
      Id = users.Id,
      Roles = Roles.Membre
    };
  }

  public Task<AuthResponseDto> RegisterAsync(RegisterRequestDto dto)
  {
    if (string.IsNullOrEmpty(dto.Pseudo) || string.IsNullOrEmpty(dto.Password) || string.IsNullOrEmpty(dto.Email))
    {
      throw new Exception("missing required fields");
    }
  }
}