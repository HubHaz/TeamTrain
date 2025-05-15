using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using StackExchange.Redis;
using TeamTrain.Application.Interfaces.Notifications;
using TeamTrain.Domain;

namespace TeamTrain.Application.Hubs;

[Authorize]
public class NotificationHub(
IConnectionMultiplexer redis,
IHubConnections hubConnections) : Hub
{
    private readonly IDatabase _db = redis.GetDatabase();

    public override async Task OnConnectedAsync()
    {
        var userId = Context.User?.FindFirst(Consts.JwtClaimIdentifiers.Id)?.Value;

        if (!string.IsNullOrEmpty(userId))
        {
            hubConnections.AddUserConnection(userId, Context.ConnectionId);
            await Clients.Caller.SendAsync("ReceiveMessage", JsonConvert.SerializeObject("Welcome to the notifications system!"));

            await RetrieveAndSendPendingNotificationsAsync(userId);
        }

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception exception)
    {
        var userId = Context.User?.FindFirst(Consts.JwtClaimIdentifiers.Id)?.Value;
        if (!string.IsNullOrEmpty(userId))
            hubConnections.RemoveUserConnection(userId);

        await base.OnDisconnectedAsync(exception);
    }

    public async Task SendMessage(string user, string message)
    {
        await Clients.User(user).SendAsync("ReceiveMessage", message);
    }

    public async Task RetrieveAndSendPendingNotificationsAsync(string userId)
    {
        var pendingNotifications = await _db.ListRangeAsync($"notifications:{userId}");

        foreach (var notification in pendingNotifications)
        {
            await SendMessage(userId, notification);
            await _db.ListRemoveAsync($"notifications:{userId}", notification);
        }
    }
}