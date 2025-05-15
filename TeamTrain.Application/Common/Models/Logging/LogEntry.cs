using TeamTrain.Domain.Enums.Logging;

namespace TeamTrain.Application.Common.Models.Logging;

public class LogEntry
{
    public string Message { get; set; }
}

public class UserActionLogEntry
{
    public string UserId { get; set; }
    public string Action { get; set; }
    public ActionType ActionType { get; set; }
}