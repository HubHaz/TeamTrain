using TeamTrain.Application.Common.Models;
using TeamTrain.Application.DTOs.Tenants.Auth;

namespace TeamTrain.Application.Interfaces.Tenants.Auth;

public interface IAuthService
{
    Task<ServiceResponse<AuthResult>> RegisterAsync(RegisterDto registerDto);
    Task<ServiceResponse<AuthResult>> LoginAsync(LoginDto loginDto);
    Task<ServiceResponse<AuthResult>> RefreshTokenAsync(string refreshToken);
}