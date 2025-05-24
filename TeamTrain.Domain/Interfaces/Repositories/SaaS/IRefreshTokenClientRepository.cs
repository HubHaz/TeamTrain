using TeamTrain.Domain.Entities.Auth;

namespace TeamTrain.Domain.Interfaces.Repositories.SaaS;

public interface IRefreshTokenClientRepository
{
    Task<RefreshTokenClient> GetByTokenAsync(string token);
    Task AddAsync(RefreshTokenClient refreshToken);
    Task UpdateAsync(RefreshTokenClient refreshToken);
    Task DeleteAsync(Guid id);
}