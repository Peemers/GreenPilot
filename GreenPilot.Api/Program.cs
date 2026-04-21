using System.Text;
using GreenPilot.Core.Interfaces.Repositories;
using GreenPilot.Core.Interfaces.Services;
using GreenPilot.Core.Interfaces.Tools;
using GreenPilot.Core.Services;
using GreenPilot.Infrastructure.DataBase.Context;
using GreenPilot.Infrastructure.Repositories;
using GreenPilot.Infrastructure.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration() //création logger avant tout le reste dans program
  .MinimumLevel.Override("Microsoft", LogEventLevel.Information) //niveau d'info
  .Enrich.FromLogContext() //
  .WriteTo.Console()
  .CreateBootstrapLogger(); //log de démarrage

var builder = WebApplication.CreateBuilder(args);

#region dbContext

builder.Services.AddDbContext<GreenPilotDbContext>(option =>
  option.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

#endregion

#region Cors

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

#endregion

#region Injection

#region Classic Injection

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IHashPassword, HashePassword>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IRunRepository, RunRepository>();
builder.Services.AddScoped<IRunService, RunService>();
builder.Services.AddControllers();
builder.Services.AddOpenApi();

#endregion

#region Jwt Injection

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddJwtBearer(options =>
  {
    options.TokenValidationParameters = new TokenValidationParameters
    {
      ValidateIssuer = true,
      ValidateAudience = true,
      ValidateLifetime = true,
      ValidateIssuerSigningKey = true,
      ValidIssuer = builder.Configuration["Jwt:Issuer"],
      ValidAudience = builder.Configuration["Jwt:Audience"],
      IssuerSigningKey = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
    };
  });

#endregion

#region SerilogConfig

builder.Host.UseSerilog((context, services, configuration) => configuration
  .ReadFrom.Configuration(context.Configuration)
  .ReadFrom.Services(services)
  .Enrich.FromLogContext());

#endregion

#endregion

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