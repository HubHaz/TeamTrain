namespace TeamTrain.Infrastructure.Multitenancy;

public interface ITenantProvider
{
    TenantDto? CurrentTenant { get; }
    void SetTenant(TenantDto tenant);
}