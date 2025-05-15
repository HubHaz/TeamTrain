using TeamTrain.Application.Interfaces.Logging;
using TeamTrain.Application.Interfaces.Notifications;
using TeamTrain.Application.Services.Logging;
using TeamTrain.Application.Services.Notifications;

namespace TeamTrain.WebApi.Configurations;

public static class ServicesSetup
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services
            .AddSingleton<IApplicationLogService, ApplicationLogService>()
            .AddSingleton<IUserActionLogger, UserActionLogger>()
            .AddSingleton<IHubConnections, HubConnections>();

        return services;
    }
}