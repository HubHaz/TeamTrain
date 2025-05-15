using StackExchange.Redis;

namespace TeamTrain.WebApi.Configurations;

public static class SignalrSetup
{
    public static IServiceCollection RegisterSignalR(this IServiceCollection services, IConfiguration configuration)
    {
        var redisConnection = configuration.GetConnectionString("RedisConnection");

        services.AddSignalR().AddStackExchangeRedis(redisConnection, options =>
        {
            options.Configuration.ChannelPrefix = "RealTimeNotificationSystem";
        });

        services.AddSingleton<IConnectionMultiplexer>(sp =>
            ConnectionMultiplexer.Connect(redisConnection));

        return services;
    }
}