using TeamTrain.Application.Common.Models;
using TeamTrain.Application.DTOs.Common;
using TeamTrain.Application.DTOs.SaaS.Auth;
using TeamTrain.Application.Helpers;
using TeamTrain.Application.Interfaces;
using TeamTrain.Application.Interfaces.SaaS.Auth;
using TeamTrain.Domain.Entities.Portal;
using TeamTrain.Domain.Enums;
using TeamTrain.Domain.Interfaces.Repositories.SaaS;

namespace TeamTrain.Application.Services.SaaS.Auth;

public class AuthClientService(
    IPortalUserRepository portalUserRepository,
    IRefreshTokenClientRepository refreshTokenRepository,
    ITokenService tokenService) : IAuthClientService
{
    public async Task<ServiceResponse> RegisterAsync(RegisterClientDto registerDto)
    {
        if (await portalUserRepository.EmailExistsAsync(registerDto.Email))
            return ServiceResponse.ErrorResponse("Email is already in use.");

        var user = new PortalUser
        {
            Id = Guid.NewGuid(),
            Email = registerDto.Email,
            PasswordHash = PasswordHasher.HashPassword(registerDto.Password),
            Role = PortalRoleType.Customer,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await portalUserRepository.AddAsync(user);

        return ServiceResponse.SuccessResponse("User registered successfully.");
    }

    public async Task<ServiceResponse<AuthClientResult>> LoginAsync(LoginClientDto loginDto)
    {
        var user = await portalUserRepository.GetByEmailAsync(loginDto.Email);

        if (user == null || !PasswordHasher.VerifyPasswordHash(loginDto.Password, user.PasswordHash))
            return ServiceResponse<AuthClientResult>.ErrorResponse("Invalid credentials.");

        var tokenUserDto = new TokenUserDto
        {
            Id = user.Id,
            Email = user.Email,
            Role = user.Role.ToString()
        };

        var accessToken = tokenService.GenerateAccessToken(tokenUserDto);
        var refreshToken = tokenService.GenerateRefreshToken();

        var authResult = new AuthClientResult
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };

        return ServiceResponse<AuthClientResult>.SuccessResponse(authResult, "Login successful.");
    }

    public async Task<ServiceResponse<AuthClientResult>> RefreshTokenAsync(string refreshToken)
    {
        var token = await refreshTokenRepository.GetByTokenAsync(refreshToken);

        if (token == null)
            return ServiceResponse<AuthClientResult>.ErrorResponse("Invalid or expired refresh token.");

        var user = await portalUserRepository.GetByIdAsync(token.UserId);
        if (user == null)
            return ServiceResponse<AuthClientResult>.ErrorResponse("User not found.");

        var tokenUserDto = new TokenUserDto
        {
            Id = user.Id,
            Email = user.Email,
            Role = user.Role.ToString()
        };

        var newAccessToken = tokenService.GenerateAccessToken(tokenUserDto);
        var newRefreshToken = tokenService.GenerateRefreshToken();

        var authResult = new AuthClientResult
        {
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken
        };

        return ServiceResponse<AuthClientResult>.SuccessResponse(authResult, "Token refreshed.");
    }
}