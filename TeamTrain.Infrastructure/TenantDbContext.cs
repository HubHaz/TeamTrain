using Microsoft.EntityFrameworkCore;
using TeamTrain.Domain.Entities.Auth;
using TeamTrain.Domain.Entities.Portal;

namespace TeamTrain.Infrastructure;

public class TenantDbContext(DbContextOptions<TenantDbContext> options) : DbContext(options)
{
    public DbSet<Tenant> Tenants => Set<Tenant>();
    public DbSet<PortalUser> PortalUsers => Set<PortalUser>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
}