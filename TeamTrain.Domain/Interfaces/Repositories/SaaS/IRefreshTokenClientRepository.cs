using TeamTrain.Domain.Entities.Auth;

namespace TeamTrain.Domain.Interfaces.Repositories.SaaS;

public interface IRefreshTokenClientRepository
{
    Task<RefreshToken> GetByTokenAsync(string token);
    Task AddAsync(RefreshToken refreshToken);
    Task UpdateAsync(RefreshToken refreshToken);
    Task DeleteAsync(Guid id);
}