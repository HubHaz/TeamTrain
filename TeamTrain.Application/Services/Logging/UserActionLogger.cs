using Microsoft.Extensions.Logging;
using Serilog.Context;
using TeamTrain.Application.Interfaces.Logging;
using TeamTrain.Domain.Enums.Logging;

namespace TeamTrain.Application.Services.Logging;

public class UserActionLogger(ILogger<UserActionLogger> logger) : IUserActionLogger
{
    public void LogUserAction(string userId, string action, ActionType actionType)
    {
        using (LogContext.PushProperty("UserId", userId))
        using (LogContext.PushProperty("ActionType", actionType))
        {
            logger.LogInformation("User performed action: {Action}", action);
        }
    }

    public void LogError(string userId, Exception exception, string message)
    {
        using (LogContext.PushProperty("UserId", userId))
        {
            logger.LogError(exception, message);
        }
    }
}