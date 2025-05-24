using MediatR;
using TeamTrain.Application.Common.Models;
using TeamTrain.Application.DTOs.SaaS.Auth;

namespace TeamTrain.Application.CQRS.SaaS.Commands.Auth;

public class RefreshTokenClientCommand(string refreshToken) : IRequest<ServiceResponse<AuthClientResult>>
{
    public string RefreshToken { get; set; } = refreshToken;
}
