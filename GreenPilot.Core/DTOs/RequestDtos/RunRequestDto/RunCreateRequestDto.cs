using System.ComponentModel.DataAnnotations;
using GreenPilot.Domain.Enums;

namespace GreenPilot.Core.DTOs.RequestDtos.RunRequestDto;

public record RunCreateRequestDto(
  [Required(ErrorMessage = "Il faut définir un statut")] Statuts Statut,
  [Required(ErrorMessage = "Date de démarrage requise")] DateTime StartDate,
  [MaxLength(250)] string Remark,
  [Required] int NumberOfPlants);
  
  
