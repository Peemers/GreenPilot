using GreenPilot.Core.DTOs.RequestDtos.RunRequestDto;
using GreenPilot.Core.DTOs.ResponseDtos.RunResponseDto;
using GreenPilot.Core.Interfaces.Services;
using GreenPilot.Domain.Entities;
using GreenPilot.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GreenPilot.Controllers;

[Microsoft.AspNetCore.Components.Route("api/[controller]")]
[ApiController]
public class RunController(IRunService runService) : ControllerBase
{
  #region CreateRun

  [HttpPost]
  public async Task<ActionResult<RunDetailsResponseDto>> CreateRun([FromBody] RunCreateRequestDto run, Guid userid)
  {
    try
    {
      RunDetailsResponseDto result = await runService.CreateRunAsync(run, userid);
      return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }
    catch (Exception e)
    {
      return BadRequest(new { message = e.Message });
    }
  }

  #endregion

  #region DeleteRun

  [HttpDelete]
  public async Task<IActionResult> DeleteRun(Guid id)
  {
    try
    {
      await runService.DeleteRunAsync(id);
      return NoContent();
    }
    catch (Exception e)
    {
      return BadRequest(new { message = e.Message });
    }
  }

  #endregion

  #region GetById

  [HttpGet]
  public async Task<ActionResult<RunDetailsResponseDto>> GetById(Guid id)
  {
    try
    {
      RunDetailsResponseDto result = await runService.GetRunByIdAsync(id);
      return Ok(result);
    }
    catch (Exception e)
    {
      return BadRequest(new { message = e.Message });
    }
  }

  #endregion

  #region GetByUserId

  [HttpGet]
  public async Task<ActionResult<IEnumerable<RunShortResponseDto>>> GetByUserId(Guid id)
  {
    try
    {
      IEnumerable<RunShortResponseDto> result = await runService.GetByUserIdAsync(id);
      return Ok(result);
    }
    catch (Exception e)
    {
      return BadRequest(new { message = e.Message });
    }
  }

  #endregion

  #region GetAllRuns

  [HttpGet]
  public async Task<ActionResult<IEnumerable<RunShortResponseDto>>> GetAllRuns()
  {
    try
    {
      IEnumerable<RunShortResponseDto> result = await runService.GetAllRunsAsync();
      return Ok(result);
    }
    catch (Exception e)
    {
      return BadRequest(new { message = e.Message });
    }
  }

  #endregion

  #region GetByStatus

  [HttpGet]
  public async Task<ActionResult<IEnumerable<RunShortResponseDto>>> GetByStatus(Statuts statuts)
  {
    try
    {
      IEnumerable<RunShortResponseDto> result = await runService.GetByStatusAsync(statuts);
      return Ok(result);
    }
    catch (Exception e)
    {
      return BadRequest(new { message = e.Message });
    }
  }

  #endregion

  #region UpdateRun

  [HttpPut]
  public async Task<ActionResult<RunDetailsResponseDto>> UpdateRun([FromBody] RunUpdateRequestDto run, Guid id)
  {
    try
    {
      RunDetailsResponseDto result = await runService.UpdateRunAsync(run, id);
      return Ok(result);
    }
    catch (Exception e)
    {
      return BadRequest(new { message = e.Message });
    }
  }

  #endregion

  [HttpPatch]
  public async Task<IActionResult> RunStart(Guid id)
  {
    try
    {
      RunDetailsResponseDto result = await runService.RunStartAsync(id);
      return Ok(result);
    }
    catch (Exception e)
    {
      return BadRequest(new { message = e.Message });
    }
  }
}