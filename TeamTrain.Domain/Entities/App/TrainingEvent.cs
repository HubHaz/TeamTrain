using TeamTrain.Domain.Interfaces;

namespace TeamTrain.Domain.Entities.App;

public class TrainingEvent : IEntity<Guid>
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public string Name { get; set; }

    public Guid CoachId { get; set; }
    public User Coach { get; set; }

    public DateTime StartTime { get; set; }
    public TimeSpan Duration { get; set; }

    public string Location { get; set; }
    public int Capacity { get; set; }

    public bool IsRecurring { get; set; }
    public string? RecurrencePattern { get; set; }

    public ICollection<UserTrainingSignup> Signups { get; set; }
}
