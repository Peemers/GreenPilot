using System.ComponentModel.DataAnnotations;
using GreenPilot.Domain.Enums;

namespace GreenPilot.Core.DTOs.RequestDtos.RunRequestDto;

public record RunCreateRequestDto
{
  [Required(ErrorMessage = "Il faut définir un statut")]
  public Statuts Statut { get; init; }

  [Required(ErrorMessage = "Date de démarrage requise")]
  public DateTime StartDate { get; init; }
  
  public string Remark { get; init; } = string.Empty;

  [Required]
  public int NumberOfPlants { get; init; }
}
  
  
