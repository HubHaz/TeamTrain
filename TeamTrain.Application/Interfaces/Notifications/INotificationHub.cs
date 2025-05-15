namespace TeamTrain.Application.Interfaces.Notifications;

public interface INotificationHub
{
    Task SendMessage(string message);
    Task SendToUser(string message, string user);
}