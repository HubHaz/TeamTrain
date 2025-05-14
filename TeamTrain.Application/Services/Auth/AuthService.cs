using TeamTrain.Application.Common.Models;
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
    public async Task<ServiceResponse<AuthResult>> RegisterAsync(RegisterDto registerDto)
    {
        if (await userRepository.EmailExistsAsync(registerDto.Email))
            return ServiceResponse<AuthResult>.ErrorResponse("Email is already in use.");

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = registerDto.Email,
            PasswordHash = PasswordHasher.HashPassword(registerDto.Password),
            Role = RoleType.Participant,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await userRepository.AddAsync(user);
        await unitOfWork.SaveChangesAsync();

        var accessToken = tokenService.GenerateAccessToken(user);
        var refreshToken = tokenService.GenerateRefreshToken(user);

        var authResult = new AuthResult
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };

        return ServiceResponse<AuthResult>.SuccessResponse(authResult, "User registered successfully.");
    }

    public async Task<ServiceResponse<AuthResult>> LoginAsync(LoginDto loginDto)
    {
        var user = await userRepository.GetByEmailAsync(loginDto.Email);

        if (user == null || !PasswordHasher.VerifyPasswordHash(loginDto.Password, user.PasswordHash))
            return ServiceResponse<AuthResult>.ErrorResponse("Invalid credentials.");

        var accessToken = tokenService.GenerateAccessToken(user);
        var refreshToken = tokenService.GenerateRefreshToken(user);

        var authResult = new AuthResult
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };

        return ServiceResponse<AuthResult>.SuccessResponse(authResult, "Login successful.");
    }

    public async Task<ServiceResponse<AuthResult>> RefreshTokenAsync(string refreshToken)
    {
        var token = await refreshTokenRepository.GetByTokenAsync(refreshToken);

        if (token == null)
            return ServiceResponse<AuthResult>.ErrorResponse("Invalid or expired refresh token.");

        var user = await userRepository.GetByIdAsync(token.UserId);
        if (user == null)
            return ServiceResponse<AuthResult>.ErrorResponse("User not found.");

        var newAccessToken = tokenService.GenerateAccessToken(user);
        var newRefreshToken = tokenService.GenerateRefreshToken(user);

        var authResult = new AuthResult
        {
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken
        };

        return ServiceResponse<AuthResult>.SuccessResponse(authResult, "Token refreshed.");
    }
}