using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GreenPilot.Core.Interfaces.Tools;
using GreenPilot.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace GreenPilot.Infrastructure.Security;

public class JwtService(IConfiguration  configuration) : IJwtService
{
  public string GenererToken(UserEntity user)
  {
    //Claims, infos contenue dans le token
    Claim[] claims =
    [
      new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
      new Claim(JwtRegisteredClaimNames.Email, user.Email),
      new Claim(JwtRegisteredClaimNames.Nickname, user.Pseudo),
      new Claim(ClaimTypes.Role, user.Role.ToString())
    ];
    
    //recup clé secrete dans appsetting
    SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
    
    //signature
    SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    
    //creation
    JwtSecurityToken token = new JwtSecurityToken(
      issuer: configuration["Jwt:Issuer"],
      audience: configuration["Jwt:Audience"],
      claims: claims,
      expires: DateTime.UtcNow.AddHours(2),
      signingCredentials: creds
    );
    return new JwtSecurityTokenHandler().WriteToken(token);
  }
}