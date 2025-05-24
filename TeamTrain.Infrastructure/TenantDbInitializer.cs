﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace TeamTrain.Infrastructure;

public class TenantDbInitializer : IHostedService
{
    private readonly ILogger<TenantDbContext> _logger;
    private readonly IServiceProvider _serviceProvider;

    public TenantDbInitializer(ILogger<TenantDbContext> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await using var scope = _serviceProvider.CreateAsyncScope();

        var context = scope.ServiceProvider.GetRequiredService<TenantDbContext>();

        var strategy = context.Database.CreateExecutionStrategy();
        _logger.LogInformation("Running migrations for {Context}", nameof(TenantDbContext));
        await strategy.ExecuteAsync(async () => await context.Database.MigrateAsync(cancellationToken: cancellationToken));
        _logger.LogInformation("Migrations applied successfully");
    }

    public Task StopAsync(CancellationToken cancellationToken) =>
        Task.CompletedTask;
}