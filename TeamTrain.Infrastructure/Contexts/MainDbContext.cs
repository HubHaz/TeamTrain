using Microsoft.EntityFrameworkCore;
using TeamTrain.Domain.Entities.Auth;
using TeamTrain.Domain.Entities.Portal;

namespace TeamTrain.Infrastructure.Contexts;

public class MainDbContext(DbContextOptions<MainDbContext> options) : DbContext(options)
{
    public DbSet<Tenant> Tenants => Set<Tenant>();
    public DbSet<PortalUser> PortalUsers => Set<PortalUser>();
    public DbSet<RefreshTokenClient> RefreshTokens => Set<RefreshTokenClient>();
}