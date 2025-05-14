using TeamTrain.Domain.Interfaces.Repositories;

namespace TeamTrain.Domain.Interfaces.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    ITrainingRepository Trainings { get; }
    IUserRepository Users { get; }
    IMembershipRepository Memberships { get; }
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}