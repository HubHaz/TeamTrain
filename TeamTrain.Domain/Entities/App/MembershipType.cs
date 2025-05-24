using TeamTrain.Domain.Interfaces;

namespace TeamTrain.Domain.Entities.App;

public class MembershipType : IEntity<Guid>
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public string Name { get; set; }
    public int? EntryLimit { get; set; } // null = unlimited
    public int ValidForDays { get; set; }

    public ICollection<Membership> Memberships { get; set; }
}