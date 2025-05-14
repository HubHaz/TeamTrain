using TeamTrain.Domain.Interfaces.UnitOfWork;
using TeamTrain.Domain.Interfaces.Repositories;

namespace TeamTrain.Infrastructure.Persistence.UnitOfWork;

public class UnitOfWork(ApplicationDbContext context,
                  ITrainingRepository trainings,
                  IUserRepository users,
                  IMembershipRepository memberships) : IUnitOfWork
{

    public ITrainingRepository Trainings { get; } = trainings;
    public IUserRepository Users { get; } = users;
    public IMembershipRepository Memberships { get; } = memberships;

    public Task SaveChangesAsync(CancellationToken cancellationToken = default) => context.SaveChangesAsync(cancellationToken);
    public void Dispose() => context.Dispose();
}