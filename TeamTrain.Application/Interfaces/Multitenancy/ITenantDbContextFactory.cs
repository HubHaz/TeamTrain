using TeamTrain.Infrastructure.Contexts;

namespace TeamTrain.Application.Interfaces.Multitenancy;

public interface ITenantDbContextFactory
{
    TenantDbContext Create(string connectionString);
}