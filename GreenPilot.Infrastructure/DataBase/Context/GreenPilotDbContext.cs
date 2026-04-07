using GreenPilot.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GreenPilot.Infrastructure.DataBase.Context;

public class GreenPilotDbContext(DbContextOptions<GreenPilotDbContext> options) : DbContext(options)
{
  public DbSet<UserEntity> Users { get; set; } = null!;
  public DbSet<RunEntity> Runs { get; set; } = null!;

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(GreenPilotDbContext).Assembly);
  }
}