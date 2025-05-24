using TeamTrain.Domain.Entities.App;
using TeamTrain.Domain.Enums;

namespace TeamTrain.Domain.Interfaces.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
    Task<List<User>> GetByRoleAsync(RoleType role);
    Task<bool> EmailExistsAsync(string email);
}