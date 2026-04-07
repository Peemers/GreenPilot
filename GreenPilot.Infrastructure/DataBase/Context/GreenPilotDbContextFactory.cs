using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace GreenPilot.Infrastructure.DataBase.Context;

public class GreenPilotDbContextFactory : IDesignTimeDbContextFactory<GreenPilotDbContext>
{
  public GreenPilotDbContext CreateDbContext(string[] args)
  {
    string path = Path.Combine(Directory.GetCurrentDirectory(), "..", "GreenPilot.Api");

    IConfigurationRoot configuration = new ConfigurationBuilder()
      .SetBasePath(path)
      .AddJsonFile("appsettings.development.json")
      .Build();

    string connectionString = configuration.GetConnectionString("Default")!;

    var optionBuilder = new DbContextOptionsBuilder<GreenPilotDbContext>();
    optionBuilder.UseSqlServer(connectionString);
    return new GreenPilotDbContext(optionBuilder.Options);
  }
}
