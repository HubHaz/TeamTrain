namespace TeamTrain.Infrastructure.Multitenancy;

public class TenantDto
{
    public string Name { get; set; } = default!;
    public string ConnectionString { get; set; } = default!;
}