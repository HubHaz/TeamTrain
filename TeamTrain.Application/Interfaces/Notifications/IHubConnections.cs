namespace TeamTrain.Application.Interfaces.Notifications;

public interface IHubConnections
{
    void AddUserConnection(string userId, string connectionId);
    void RemoveUserConnection(string userId);
    string GetUserConnection(string userId);
}