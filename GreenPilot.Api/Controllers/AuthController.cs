using GreenPilot.Core.DTOs.RequestDtos.UserRequestDtos;
using GreenPilot.Core.DTOs.ResponseDtos;
using GreenPilot.Core.Interfaces.Services;
using GreenPilot.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace GreenPilot.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
  [HttpPost("Register")]
  [EndpointSummary("Register")]
  [EndpointDescription("Permet à un visiteur de s'enregistrer.")]
  public async Task<ActionResult<AuthResponseDto>> Register(RegisterRequestDto dto)
  {
    try
    {
      AuthResponseDto result = await authService.RegisterAsync(dto);
      return Ok(result);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPost("Login")]
  [EndpointSummary("Login")]
  [EndpointDescription("Permet à un membre de se logger")]
  public async Task<ActionResult<AuthResponseDto>> Login(LoginRequestDto dto)
  {
    try
    {
      AuthResponseDto result = await authService.LoginAsync(dto);
      return Ok(result);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}



