using TeamTrain.Application.Interfaces.Notifications;

namespace TeamTrain.Application.Services.Notifications;

public class HubConnections : IHubConnections
{
    private static Dictionary<string, List<string>> Users = [];

    public static bool HasUserConnection(string userId, string ConnectionId)
    {
        try
        {
            if (Users.TryGetValue(userId, out List<string>? value))
                return value.Any(p => p.Contains(ConnectionId));
        }
        catch (Exception)
        {
            throw;
        }

        return false;
    }

    public void AddUserConnection(string userId, string connectionId)
    {
        if (!string.IsNullOrEmpty(userId) && !HasUserConnection(userId, connectionId))
        {
            if (Users.TryGetValue(userId, out List<string>? value))
                value.Add(connectionId);
            else
                Users.Add(userId, [connectionId]);
        }
    }

    public void RemoveUserConnection(string userId)
    {
        if (!string.IsNullOrEmpty(userId) && Users.TryGetValue(userId, out List<string>? value))
            value.Clear();
    }

    public static bool HasUser(string userId)
    {
        try
        {
            if (Users.TryGetValue(userId, out List<string>? value))
                return value.Count != 0;
        }
        catch (Exception)
        {
            throw;
        }

        return false;
    }

    public string GetUserConnection(string userId)
    {
        try
        {
            if (Users.TryGetValue(userId, out List<string>? value))
                return value.First();

            return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
}