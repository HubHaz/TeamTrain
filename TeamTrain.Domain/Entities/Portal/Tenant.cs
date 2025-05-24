using TeamTrain.Domain.Interfaces;

namespace TeamTrain.Domain.Entities.Portal;

public class Tenant : IEntity<Guid>
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Name { get; set; } = null!;
    public string Subdomain { get; set; } = null!;
    public string ConnectionString { get; set; } = null!;
}