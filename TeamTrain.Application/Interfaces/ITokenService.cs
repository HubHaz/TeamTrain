using TeamTrain.Application.DTOs.Common;

namespace TeamTrain.Application.Interfaces;

public interface ITokenService
{
    string GenerateAccessToken(TokenUserDto user, string? tenantId = null);
    string GenerateRefreshToken();
}