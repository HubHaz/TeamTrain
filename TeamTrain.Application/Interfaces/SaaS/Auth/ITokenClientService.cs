using TeamTrain.Domain.Entities.Portal;

namespace TeamTrain.Application.Interfaces.SaaS.Auth;

public interface ITokenClientService
{
    string GenerateAccessToken(PortalUser user);
    string GenerateRefreshToken(PortalUser user);
}