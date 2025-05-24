using Microsoft.EntityFrameworkCore;
using TeamTrain.Domain.Entities.App;
using TeamTrain.Domain.Entities.Auth;
using TeamTrain.Infrastructure.Multitenancy;

namespace TeamTrain.Infrastructure.Contexts;

public class TenantDbContext(DbContextOptions<TenantDbContext> options, 
    ITenantProvider tenantProvider) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (tenantProvider.CurrentTenant == null)
            throw new InvalidOperationException("No tenant available");

        optionsBuilder.UseNpgsql(tenantProvider.CurrentTenant.ConnectionString);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Training> Trainings { get; set; }
    public DbSet<Membership> Memberships { get; set; }
    public DbSet<MembershipType> MembershipTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TenantDbContext).Assembly);
    }
}