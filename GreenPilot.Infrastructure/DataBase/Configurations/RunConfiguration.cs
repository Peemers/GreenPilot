using GreenPilot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GreenPilot.Infrastructure.DataBase.Configurations;

public class RunConfiguration : IEntityTypeConfiguration<RunEntity>
{
  public void Configure(EntityTypeBuilder<RunEntity> builder)
  {
    builder.HasKey(r => r.Id);

    builder.Property(r => r.Id)
      .IsRequired()
      .HasColumnName("Id")
      .ValueGeneratedOnAdd();

    builder.Property(r => r.Statut)
      .HasConversion<string>()
      .IsRequired()
      .HasColumnName("Statut")
      .HasMaxLength(25);
    
    builder.Property(r => r.StartDate )
      .IsRequired()
      .HasColumnName("StartTime");
    
    builder.Property(r => r.PlantingDate )
      .HasColumnName("PlantingDate");
    
    builder.Property(r => r.EndSeedlingDate )
      .HasColumnName("EndSeedlingDate");
    
    builder.Property(r => r.FloweringBeginDate)
      .HasColumnName("FloweringBeginDate");
    
    builder.Property(r => r.EndDate)
      .HasColumnName("EndDate");
    
    builder.Property(r => r.Remark)
      .HasColumnName("Remark")
      .HasMaxLength(250);
    
    builder.Property(r => r.UrlPics)
      .HasColumnName("UrlPics")
      .HasMaxLength(2048);
    
    builder.Property(r => r.NumberOfPlants)
      .IsRequired()
      .HasColumnName("PlantsNumber");

    builder.HasIndex(r => r.UserId);
  }
}