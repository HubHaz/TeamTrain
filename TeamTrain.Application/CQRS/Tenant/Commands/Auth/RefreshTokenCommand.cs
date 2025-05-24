using MediatR;
using TeamTrain.Application.Common.Models;
using TeamTrain.Application.DTOs.Tenant.Auth;

namespace TeamTrain.Application.CQRS.Tenant.Commands.Auth;

public class RefreshTokenCommand(string refreshToken) : IRequest<ServiceResponse<AuthResult>>
{
    public string RefreshToken { get; set; } = refreshToken;
}
