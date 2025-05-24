using TeamTrain.Application.Interfaces.Multitenancy;
using TeamTrain.Infrastructure.Contexts;

namespace TeamTrain.Application.Services.Multitenancy;

public class TenantDbContextFactory : ITenantDbContextFactory
{
    public TenantDbContext Create(string connectionString)
    {
        return new TenantDbContext(connectionString);
    }
}