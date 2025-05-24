using TeamTrain.Domain.Enums;
using TeamTrain.Domain.Interfaces;

namespace TeamTrain.Domain.Entities.Portal;

public class PortalUser : IEntity<Guid>
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public Guid TenantId { get; set; }
    public PortalRoleType Role { get; set; } = PortalRoleType.Customer;
    public Tenant? Tenant { get; set; }
}