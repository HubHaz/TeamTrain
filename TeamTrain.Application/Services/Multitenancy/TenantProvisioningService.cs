using Microsoft.EntityFrameworkCore;
using TeamTrain.Application.Interfaces.Multitenancy;
using TeamTrain.Domain.Entities.Portal;
using TeamTrain.Infrastructure.Contexts;

namespace TeamTrain.Application.Services.Multitenancy;

public class TenantProvisioningService(ITenantDbContextFactory factory,
    MainDbContext mainDbContext)
{
    public async Task ProvisionTenantAsync(string subdomain)
    {
        var dbName = $"tenant_{subdomain.ToLower()}";
        var connectionString = $"Host=postgres;Port=5432;Database={dbName};Username=postgres;Password=yourpass";

        var dbContext = factory.Create(connectionString);
        await dbContext.Database.MigrateAsync();

        var tenant = new Tenant
        {
            Id = Guid.NewGuid(),
            Subdomain = subdomain.ToLower(),
            ConnectionString = connectionString,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Name = string.Empty
        };

        mainDbContext.Tenants.Add(tenant);
        await mainDbContext.SaveChangesAsync();
    }
}