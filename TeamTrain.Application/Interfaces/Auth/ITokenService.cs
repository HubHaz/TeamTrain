using TeamTrain.Domain.Entities;

namespace TeamTrain.Application.Interfaces.Auth;

public interface ITokenService
{
    string GenerateAccessToken(User user);
    string GenerateRefreshToken(User user);
}