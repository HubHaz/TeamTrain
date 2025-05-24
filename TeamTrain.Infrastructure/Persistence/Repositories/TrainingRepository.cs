using Microsoft.EntityFrameworkCore;
using TeamTrain.Domain.Entities.App;
using TeamTrain.Domain.Interfaces.Repositories;
using TeamTrain.Infrastructure.Contexts;

namespace TeamTrain.Infrastructure.Persistence.Repositories;

public class TrainingRepository : ITrainingRepository
{
    private readonly TenantDbContext _context;
    private readonly DbSet<Training> _trainings;

    public TrainingRepository(TenantDbContext context)
    {
        _context = context;
        _trainings = _context.Trainings;
    }
}