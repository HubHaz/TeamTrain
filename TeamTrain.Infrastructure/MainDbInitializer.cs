using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TeamTrain.Infrastructure.Contexts;

namespace TeamTrain.Infrastructure;

public class MainDbInitializer(
    ILogger<MainDbContext> logger, 
    IServiceProvider serviceProvider) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await using var scope = serviceProvider.CreateAsyncScope();

        var context = scope.ServiceProvider.GetRequiredService<MainDbContext>();

        var strategy = context.Database.CreateExecutionStrategy();
        logger.LogInformation("Running migrations for {Context}", nameof(MainDbContext));
        await strategy.ExecuteAsync(async () => await context.Database.MigrateAsync(cancellationToken: cancellationToken));
        logger.LogInformation("Migrations applied successfully");
    }

    public Task StopAsync(CancellationToken cancellationToken) =>
        Task.CompletedTask;
}