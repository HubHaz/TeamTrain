namespace TeamTrain.Infrastructure.Multitenancy;

public class TenantProvider : ITenantProvider
{
    private TenantDto? _tenant;

    public TenantDto? CurrentTenant => _tenant;

    public void SetTenant(TenantDto tenant)
    {
        _tenant = tenant;
    }
}