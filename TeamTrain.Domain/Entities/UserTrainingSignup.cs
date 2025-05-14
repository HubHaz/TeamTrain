using TeamTrain.Domain.Interfaces;

namespace TeamTrain.Domain.Entities;

public class UserTrainingSignup : IEntity<Guid>
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }

    public Guid TrainingEventId { get; set; }
    public TrainingEvent TrainingEvent { get; set; }

    public DateTime SignupDateTime { get; set; }
    public DateTime? CancelledAt { get; set; }
    public bool PenaltyApplied { get; set; }
}
