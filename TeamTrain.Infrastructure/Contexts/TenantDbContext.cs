using Microsoft.EntityFrameworkCore;
using TeamTrain.Domain.Entities.App;
using TeamTrain.Domain.Entities.Auth;
using TeamTrain.Infrastructure.Multitenancy;

namespace TeamTrain.Infrastructure.Contexts;

public class TenantDbContext : DbContext
{
    private readonly string? _connectionString;

    public TenantDbContext(DbContextOptions<TenantDbContext> options, ITenantProvider tenantProvider)
        : base(options)
    {
        _connectionString = tenantProvider.CurrentTenant?.ConnectionString;
    }

    public TenantDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (string.IsNullOrWhiteSpace(_connectionString))
            throw new InvalidOperationException("No connection string provided for tenant");

        optionsBuilder.UseNpgsql(_connectionString);
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