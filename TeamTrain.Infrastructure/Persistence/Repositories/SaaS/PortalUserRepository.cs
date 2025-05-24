using Microsoft.EntityFrameworkCore;
using TeamTrain.Domain.Entities.Portal;
using TeamTrain.Domain.Enums;
using TeamTrain.Domain.Interfaces.Repositories.SaaS;
using TeamTrain.Infrastructure.Contexts;

namespace TeamTrain.Infrastructure.Persistence.Repositories.SaaS;

public class PortalUserRepository : IPortalUserRepository
{
    private readonly MainDbContext _context;
    private readonly DbSet<PortalUser> _users;

    public PortalUserRepository(MainDbContext context)
    {
        _context = context;
        _users = _context.PortalUsers;
    }

    public Task<PortalUser?> GetByIdAsync(Guid id) => _users.FirstOrDefaultAsync(u => u.Id == id);

    public Task<List<PortalUser>> FindAsync(System.Linq.Expressions.Expression<Func<PortalUser, bool>> predicate) => _users.Where(predicate).ToListAsync();

    public Task<PortalUser?> GetByEmailAsync(string email) => _users.FirstOrDefaultAsync(u => u.Email == email);

    public Task<List<PortalUser>> GetByRoleAsync(PortalRoleType role) => _users.Where(u => u.Role == role).ToListAsync();

    public Task<bool> EmailExistsAsync(string email) => _users.AnyAsync(u => u.Email == email);

    public Task AddAsync(PortalUser user) => _users.AddAsync(user).AsTask();

    public void Update(PortalUser user) => _users.Update(user);

    public void Remove(PortalUser user) => _users.Remove(user);
}