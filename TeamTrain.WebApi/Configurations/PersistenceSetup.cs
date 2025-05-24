using Microsoft.EntityFrameworkCore;
using TeamTrain.Infrastructure;
using TeamTrain.Infrastructure.Contexts;
using TeamTrain.Infrastructure.Multitenancy;

namespace TeamTrain.WebApi.Configurations;

public static class PersistenceSetup
{
    public static IServiceCollection AddPersistenceSetup(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MainDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("MainDb")));

        services.AddDbContext<TenantDbContext>((serviceProvider, options) =>
        {
            var tenantProvider = serviceProvider.GetRequiredService<ITenantProvider>();
            var tenantConnectionString = tenantProvider.GetConnectionString();
            options.UseNpgsql(tenantConnectionString);
        });

        services.AddHostedService<MainDbInitializer>();

        return services;
    }
}