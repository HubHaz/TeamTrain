using TeamTrain.Application.DTOs.Auth;
using TeamTrain.Application.Helpers;
using TeamTrain.Application.Interfaces.Auth;
using TeamTrain.Domain.Entities;
using TeamTrain.Domain.Enums;
using TeamTrain.Domain.Interfaces.Repositories;
using TeamTrain.Domain.Interfaces.UnitOfWork;

namespace TeamTrain.Application.Services.Auth;

public class AuthService(
    IUserRepository userRepository,
    IRefreshTokenRepository refreshTokenRepository,
    IUnitOfWork unitOfWork,
    ITokenService tokenService) : IAuthService
{
    public async Task<AuthResult> RegisterAsync(RegisterDto registerDto)
    {
        if (await userRepository.EmailExistsAsync(registerDto.Email))
        {
            return new AuthResult
            {
                Success = false,
                Errors = ["Email is already in use."]
            };
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = registerDto.Email,
            PasswordHash = PasswordHasher.HashPassword(registerDto.Password),
            Role = RoleType.Participant,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        await userRepository.AddAsync(user);
        await unitOfWork.SaveChangesAsync();

        var accessToken = tokenService.GenerateAccessToken(user);
        var refreshToken = tokenService.GenerateRefreshToken(user);

        return new AuthResult
        {
            Success = true,
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }

    public async Task<AuthResult> LoginAsync(LoginDto loginDto)
    {
        var user = await userRepository.GetByEmailAsync(loginDto.Email);

        if (user == null || !PasswordHasher.VerifyPasswordHash(loginDto.Password, user.PasswordHash))
        {
            return new AuthResult
            {
                Success = false,
                Errors = ["Invalid credentials."]
            };
        }

        var accessToken = tokenService.GenerateAccessToken(user);
        var refreshToken = tokenService.GenerateRefreshToken(user);

        return new AuthResult
        {
            Success = true,
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }

    public async Task<AuthResult> RefreshTokenAsync(string refreshToken)
    {
        var token = await refreshTokenRepository.GetByTokenAsync(refreshToken);

        if (token == null)
        {
            return new AuthResult
            {
                Success = false,
                Errors = ["Invalid or expired refresh token."]
            };
        }

        var user = await userRepository.GetByIdAsync(token.UserId);
        if (user == null)
        {
            return new AuthResult
            {
                Success = false,
                Errors = ["User not found."]
            };
        }

        var newAccessToken = tokenService.GenerateAccessToken(user);
        var newRefreshToken = tokenService.GenerateRefreshToken(user);

        return new AuthResult
        {
            Success = true,
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken
        };
    }
}