using TeamTrain.Application.Common.Models;
using TeamTrain.Application.DTOs.SaaS.Auth;

namespace TeamTrain.Application.Interfaces.SaaS.Auth;

public interface IAuthClientService
{
    Task<ServiceResponse<AuthClientResult>> RegisterAsync(RegisterClientDto registerDto);
    Task<ServiceResponse<AuthClientResult>> LoginAsync(LoginClientDto loginDto);
    Task<ServiceResponse<AuthClientResult>> RefreshTokenAsync(string refreshToken);
}