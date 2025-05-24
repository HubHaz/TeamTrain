using Microsoft.EntityFrameworkCore;
using TeamTrain.Domain.Entities.App;
using TeamTrain.Domain.Entities.Auth;

namespace TeamTrain.Infrastructure;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Training> Trainings { get; set; }
    public DbSet<Membership> Memberships { get; set; }
    public DbSet<MembershipType> MembershipTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("teamtrain");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}