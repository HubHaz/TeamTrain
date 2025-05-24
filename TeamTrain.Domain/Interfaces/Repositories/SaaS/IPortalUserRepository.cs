using TeamTrain.Domain.Entities.Portal;
using TeamTrain.Domain.Enums;

namespace TeamTrain.Domain.Interfaces.Repositories.SaaS;

public interface IPortalUserRepository : IRepository<PortalUser>
{
    Task<PortalUser?> GetByEmailAsync(string email);
    Task<List<PortalUser>> GetByRoleAsync(PortalRoleType role);
    Task<bool> EmailExistsAsync(string email);
}