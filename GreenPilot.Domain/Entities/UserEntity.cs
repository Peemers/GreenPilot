using GreenPilot.Domain.Enums;

namespace GreenPilot.Domain.Entities;

public class UserEntity : BaseEntity
{
  public required string Pseudo { get; set; }
  public required string Email { get; set; }
  public required string Password { get; set; }
  public Roles Role { get; set; }
  
  public ICollection<RunEntity> Runs { get; set; } = new List<RunEntity>();
}