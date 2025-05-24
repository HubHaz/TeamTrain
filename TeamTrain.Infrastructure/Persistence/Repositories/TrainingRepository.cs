using Microsoft.EntityFrameworkCore;
using TeamTrain.Domain.Entities.App;
using TeamTrain.Domain.Interfaces.Repositories;

namespace TeamTrain.Infrastructure.Persistence.Repositories;

public class TrainingRepository : ITrainingRepository
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<Training> _trainings;

    public TrainingRepository(ApplicationDbContext context)
    {
        _context = context;
        _trainings = _context.Trainings;
    }
}