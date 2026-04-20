using GreenPilot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GreenPilot.Infrastructure.DataBase.Configurations;

public class HarvestConfiguration : IEntityTypeConfiguration<HarvestEntity>
{
  public void Configure(EntityTypeBuilder<HarvestEntity> builder)
  {
    builder.HasKey(h => h.Id);

    builder.Property(h => h.HarvestDate)
      .HasColumnType("datetime");

    builder.Property(h => h.Weight)
      .HasMaxLength(250)
      .HasColumnType("int");
    
    builder.Property(h => h.Remark)
      .HasMaxLength(250)
      .HasColumnType("varchar(250)");

    builder.HasOne(h => h.Run)
      .WithOne(r => r.Harvest)
      .HasForeignKey<HarvestEntity>(h => h.RunId)
      .OnDelete(DeleteBehavior.Cascade);



  }
}