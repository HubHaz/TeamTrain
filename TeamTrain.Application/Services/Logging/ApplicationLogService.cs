using Microsoft.Extensions.Logging;
using TeamTrain.Application.Interfaces.Logging;

namespace TeamTrain.Application.Services.Logging;

public class ApplicationLogService(ILogger<ApplicationLogService> logger) : IApplicationLogService
{
    public void LogInformation(string message)
    {
        logger.LogInformation(message);
    }

    public void LogError(string message, Exception ex)
    {
        logger.LogError(ex, message);
    }
}