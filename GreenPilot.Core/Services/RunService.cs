using GreenPilot.Core.Interfaces.Repositories;
using GreenPilot.Core.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace GreenPilot.Core.Services;

public class RunService(
  IUserRepository userRepository,
  ILogger<RunService> logger) :