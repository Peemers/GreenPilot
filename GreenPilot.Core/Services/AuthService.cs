using System.Reflection.Metadata;
using GreenPilot.Core.DTOs.RequestDtos.UserRequestDtos;
using GreenPilot.Core.DTOs.ResponseDtos;
using GreenPilot.Core.Interfaces.Repositories;
using GreenPilot.Core.Interfaces.Services;
using GreenPilot.Core.Interfaces.Tools;
using GreenPilot.Core.Mappers;
using GreenPilot.Domain.Entities;
using GreenPilot.Domain.Enums;
using Microsoft.Extensions.Logging;

namespace GreenPilot.Core.Services;

public class AuthService(
  IUserRepository userRepository, 
  IHashPassword hashPassword,
  IJwtService jwtService,
  ILogger<AuthService> log): IAuthService
{
  public async Task<AuthResponseDto> LoginAsync(LoginRequestDto dto)
  {
    UserEntity? users = await userRepository.GetByUsernameAsync(dto.Pseudo);
    if (users == null || !hashPassword.Verify(dto.Password, users.Password))
    {
      log.LogInformation("Invalid login information");
      throw new KeyNotFoundException($"Invalid UserName, Email or Password");
    }
    return new AuthResponseDto
    {
      Pseudo = dto.Pseudo,
      Id = users.Id,
      Roles = Roles.Membre
    };
  }

  public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDto dto)
  {
    if (string.IsNullOrEmpty(dto.Pseudo) || string.IsNullOrEmpty(dto.Password) || string.IsNullOrEmpty(dto.Email))
    {
      log.LogInformation("Missing required fields");
      throw new Exception("Missing required fields");
    }

    string hashedPassword = hashPassword.Hash(dto.Password);

    UserEntity? newUser = dto.ToEntity(hashedPassword);
    
    await userRepository.AddAsync(newUser);
    
    string token = jwtService.GenererToken(newUser);

    return new AuthResponseDto
    {
      Pseudo = dto.Pseudo,
      Id = newUser.Id,
      Roles = Roles.Membre
    };
  }
}