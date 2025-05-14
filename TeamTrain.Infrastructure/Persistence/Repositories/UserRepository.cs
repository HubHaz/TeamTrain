using Microsoft.EntityFrameworkCore;
using TeamTrain.Domain.Entities;
using TeamTrain.Domain.Enums;
using TeamTrain.Domain.Interfaces.Repositories;

namespace TeamTrain.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<User> _users;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
        _users = _context.Users;
    }

    public Task<User?> GetByIdAsync(Guid id) => _users.FirstOrDefaultAsync(u => u.Id == id);

    public Task<List<User>> FindAsync(System.Linq.Expressions.Expression<Func<User, bool>> predicate) => _users.Where(predicate).ToListAsync();

    public Task<User?> GetByEmailAsync(string email) => _users.FirstOrDefaultAsync(u => u.Email == email);

    public Task<List<User>> GetByRoleAsync(RoleType role) => _users.Where(u => u.Role == role).ToListAsync();

    public Task<bool> EmailExistsAsync(string email) => _users.AnyAsync(u => u.Email == email);

    public Task AddAsync(User user) => _users.AddAsync(user).AsTask();

    public void Update(User user) => _users.Update(user);

    public void Remove(User user) => _users.Remove(user);
}