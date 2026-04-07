using GreenPilot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GreenPilot.Infrastructure.DataBase.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
  public void Configure(EntityTypeBuilder<UserEntity> builder)
  {
    builder.HasKey(u => u.Id);

    builder.Property(u => u.Id)
      .IsRequired()
      .HasColumnName("Id");
    builder.Property(u => u.Email)
      .IsRequired()
      .HasColumnName("Email");
    builder.Property(u => u.Password)
      .IsRequired()
      .HasColumnName("HashedPassword");
    builder.Property(u => u.Role)
      .HasColumnName("Role");

    builder.HasMany(u => u.Runs)
      .WithOne(r => r.User)
      .HasForeignKey(u => u.UserId)
      .OnDelete(DeleteBehavior.Cascade);
  }
}