namespace TeamTrain.Application.Interfaces.Logging;

public interface IApplicationLogService
{
    void LogInformation(string message);
    void LogError(string message, Exception ex);
}