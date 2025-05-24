using TeamTrain.Application.Common.Models;
using TeamTrain.Application.DTOs.Tenant.Auth;

namespace TeamTrain.Application.Interfaces.Tenant.Auth;

public interface IAuthService
{
    Task<ServiceResponse<AuthResult>> RegisterAsync(RegisterDto registerDto);
    Task<ServiceResponse<AuthResult>> LoginAsync(LoginDto loginDto);
    Task<ServiceResponse<AuthResult>> RefreshTokenAsync(string refreshToken);
}