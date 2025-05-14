using TeamTrain.Application.DTOs.Auth;

namespace TeamTrain.Application.Interfaces.Auth;

public interface IAuthService
{
    Task<AuthResult> RegisterAsync(RegisterDto registerDto);
    Task<AuthResult> LoginAsync(LoginDto loginDto);
    Task<AuthResult> RefreshTokenAsync(string refreshToken);
}