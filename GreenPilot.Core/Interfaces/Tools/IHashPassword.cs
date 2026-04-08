namespace GreenPilot.Core.Interfaces.Tools;

public interface IHashPassword
{
  string Hash(string password);
  string Verify(string hash, string password);
}