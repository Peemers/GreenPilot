using System.ComponentModel.DataAnnotations;

namespace GreenPilot.Core.DTOs.RequestDtos.UserRequestDtos;

public class RegisterRequestDto
{
  [Required(ErrorMessage = "Pseudo is required")]
  public required string Pseudo { get; init; }
  
  [Required(ErrorMessage = "Email is required")]
  public required string Email { get; init; }
  
  [Required(ErrorMessage = "Password is required")]
  public required string Password { get; init; }
}