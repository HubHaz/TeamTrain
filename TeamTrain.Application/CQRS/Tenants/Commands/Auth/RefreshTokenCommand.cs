using MediatR;
using TeamTrain.Application.Common.Models;
using TeamTrain.Application.DTOs.Tenants.Auth;

namespace TeamTrain.Application.CQRS.Tenants.Commands.Auth;

public class RefreshTokenCommand(string refreshToken) : IRequest<ServiceResponse<AuthResult>>
{
    public string RefreshToken { get; set; } = refreshToken;
}
