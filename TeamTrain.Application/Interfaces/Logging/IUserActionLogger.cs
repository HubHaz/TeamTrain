using TeamTrain.Domain.Enums.Logging;

namespace TeamTrain.Application.Interfaces.Logging;

public interface IUserActionLogger
{
    void LogUserAction(string userId, string action, ActionType actionType);
    void LogError(string userId, Exception exception, string message);
}