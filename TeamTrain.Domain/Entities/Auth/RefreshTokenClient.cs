using TeamTrain.Domain.Entities.Portal;
using TeamTrain.Domain.Interfaces;

namespace TeamTrain.Domain.Entities.Auth;

public class RefreshTokenClient : IEntity<Guid>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Token { get; set; }
    public DateTime ExpiresAt { get; set; }
    public bool IsRevoked { get; set; }
    public bool IsUsed { get; set; }
    public PortalUser User { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}