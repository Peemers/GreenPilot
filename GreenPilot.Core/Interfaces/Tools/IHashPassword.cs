namespace GreenPilot.Core.Interfaces.Tools;

public interface IHashPassword
{
  string Hash(string password);
  bool Verify(string hash, string password);
}