using TeamTrain.Domain.Entities.App;

namespace TeamTrain.Application.Interfaces.Tenants.Auth;

public interface ITokenService
{
    string GenerateAccessToken(User user);
    string GenerateRefreshToken(User user);
}