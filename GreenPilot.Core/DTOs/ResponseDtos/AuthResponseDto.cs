using GreenPilot.Domain.Enums;

namespace GreenPilot.Core.DTOs.ResponseDtos;

public class AuthResponseDto
{
  //public required string Token { get; set; }
  public required string Pseudo { get; set; }
  public required Guid Id { get; set; }
  public required Roles Roles { get; set; }
}