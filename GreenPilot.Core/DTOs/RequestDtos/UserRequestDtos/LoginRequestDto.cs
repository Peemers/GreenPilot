using System.ComponentModel.DataAnnotations;

namespace GreenPilot.Core.DTOs.RequestDtos.UserRequestDtos;

public class LoginRequestDto
{
  [Required(ErrorMessage = "Username is required")]
  public required string Pseudo { get; init; }
  
  [Required(ErrorMessage = "Password is required")]
  public required string Password { get; init; }
}