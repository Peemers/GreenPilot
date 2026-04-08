using GreenPilot.Core.DTOs.RequestDtos.UserRequestDtos;
using GreenPilot.Core.DTOs.ResponseDtos;

namespace GreenPilot.Core.Interfaces.Services;

public interface IAuthService
{
  Task<AuthResponseDto> LoginAsync(LoginRequestDto dto);
  Task<AuthResponseDto> RegisterAsync(RegisterRequestDto dto);
}