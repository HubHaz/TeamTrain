using Microsoft.EntityFrameworkCore;
using TeamTrain.Infrastructure;

namespace TeamTrain.WebApi.Configurations;

public static class PersistenceSetup
{
    public static IServiceCollection AddPersistenceSetup(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHostedService<ApplicationDbInitializer>();
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }
}