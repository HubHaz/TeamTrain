using Microsoft.EntityFrameworkCore;
using TeamTrain.Domain.Entities.Auth;
using TeamTrain.Domain.Interfaces.Repositories.SaaS;
using TeamTrain.Infrastructure.Contexts;

namespace TeamTrain.Infrastructure.Persistence.Repositories.SaaS;

public class RefreshTokenClientRepository(MainDbContext context) : IRefreshTokenClientRepository
{
    public async Task<RefreshToken> GetByTokenAsync(string token)
    {
        return await context.RefreshTokens.FirstOrDefaultAsync(r => r.Token == token && !r.IsRevoked && !r.IsUsed);
    }

    public async Task AddAsync(RefreshToken refreshToken)
    {
        await context.RefreshTokens.AddAsync(refreshToken);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(RefreshToken refreshToken)
    {
        context.RefreshTokens.Update(refreshToken);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var token = await context.RefreshTokens.FindAsync(id);
        if (token != null)
        {
            context.RefreshTokens.Remove(token);
            await context.SaveChangesAsync();
        }
    }
}