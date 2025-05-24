using Microsoft.EntityFrameworkCore;
using TeamTrain.Infrastructure;

namespace TeamTrain.WebApi.Configurations;

public static class PersistenceSetup
{
    public static IServiceCollection AddPersistenceSetup(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHostedService<TenantDbInitializer>();

        services.AddDbContext<TenantDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("TenantDb")));

        return services;
    }
}