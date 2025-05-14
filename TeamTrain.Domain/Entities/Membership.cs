using TeamTrain.Domain.Interfaces;

namespace TeamTrain.Domain.Entities;

public class Membership : IEntity<Guid>
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }

    public Guid MembershipTypeId { get; set; }
    public MembershipType MembershipType { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public int? RemainingEntries { get; set; } // dla EntryLimit
    public bool IsActive => DateTime.UtcNow >= StartDate && DateTime.UtcNow <= EndDate;
}