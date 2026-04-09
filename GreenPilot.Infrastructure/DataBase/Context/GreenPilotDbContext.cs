using GreenPilot.Domain.Entities;
using GreenPilot.Domain.Enums;
using GreenPilot.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;

namespace GreenPilot.Infrastructure.DataBase.Context;

public class GreenPilotDbContext(DbContextOptions<GreenPilotDbContext> options) : DbContext(options)
{
  public DbSet<UserEntity> Users { get; set; } = null!;
  public DbSet<RunEntity> Runs { get; set; } = null!;

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(GreenPilotDbContext).Assembly);

    var passwordHasher = new HashePassword();
    string hashedPasswordAdmin = "$2a$11$RT0btnIMe9hF7JrnJAFLd.gWiH3OK8zJ9hm.kYHxAsEkulCqDHNHG";

    Guid adminGuid = Guid.Parse("11111111-1111-1111-1111-111111111111");

    modelBuilder.Entity<UserEntity>().HasData(
      new UserEntity
      {
        Id = adminGuid,
        Pseudo = "CaroMatt",
        Email = "micro-micron@hotmail.com",
        Password = hashedPasswordAdmin,
        Role = Roles.Admin
      });
  }
}