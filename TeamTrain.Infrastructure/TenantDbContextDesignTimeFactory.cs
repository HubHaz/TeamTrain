using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TeamTrain.Infrastructure.Contexts;
using TeamTrain.Infrastructure.Multitenancy;

namespace TeamTrain.Infrastructure;

public class TenantDbContextDesignTimeFactory : IDesignTimeDbContextFactory<TenantDbContext>
{
    public TenantDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TenantDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=teamtrain_db;Username=teamtrain;Password=teamtrain_pw");

        // Tymczasowy tenant – TYLKO DO MIGRACJI
        var fakeTenantProvider = new DesignTimeTenantProvider();

        return new TenantDbContext(optionsBuilder.Options, fakeTenantProvider);
    }
}

public class DesignTimeTenantProvider : ITenantProvider
{
    public TenantDto? CurrentTenant => new()
    {
        Name = "sample",
        ConnectionString = "Host=localhost;Port=5432;Database=teamtrain_db;Username=teamtrain;Password=teamtrain_pw"
    };

    public string? GetConnectionString()
    {
        return CurrentTenant?.ConnectionString;
    }

    public void SetTenant(TenantDto tenant) { }
}
