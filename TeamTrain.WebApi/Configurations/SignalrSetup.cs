using StackExchange.Redis;

namespace TeamTrain.WebApi.Configurations;

public static class SignalrSetup
{
    public static IServiceCollection RegisterSignalR(this IServiceCollection services, IConfiguration configuration)
    {
        var redisConnectionString = configuration.GetConnectionString("RedisConnection");

        services.AddSingleton<IConnectionMultiplexer>(sp => ConnectionMultiplexer.Connect(redisConnectionString));

        services.AddSignalR().AddStackExchangeRedis(redisConnectionString, options =>
        {
            options.Configuration.ChannelPrefix = "RealTimeNotificationSystem";
        });

        return services;
    }
}