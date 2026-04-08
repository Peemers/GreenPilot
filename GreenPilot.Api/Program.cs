using GreenPilot.Core.Interfaces.Repositories;
using GreenPilot.Infrastructure.DataBase.Context;
using GreenPilot.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GreenPilotDbContext>(option => 
  option.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();

builder.Services.AddCors(option =>
{
  option.AddPolicy("AllowAngular", policy =>
  {
    policy.WithOrigins(allowedOrigins ?? Array.Empty<string>())
      .AllowAnyMethod()
      .AllowAnyHeader();
  });
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
  
builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.MapScalarApiReference();
  app.MapOpenApi();
}

app.UseCors("AllowAngular");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();