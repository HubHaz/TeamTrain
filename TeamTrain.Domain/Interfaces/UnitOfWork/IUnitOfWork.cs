namespace TeamTrain.Domain.Interfaces.UnitOfWork;

public interface IUnitOfWork
{
    ITrainingRepository Trainings { get; }
    IUserRepository Users { get; }
    IMembershipRepository Memberships { get; }
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}