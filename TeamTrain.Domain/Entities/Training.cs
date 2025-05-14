using TeamTrain.Domain.Interfaces;

namespace TeamTrain.Domain.Entities;

public class Training : IEntity<Guid>
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}