using MediatR;
using TeamTrain.Application.Common.Models;
using TeamTrain.Application.CQRS.SaaS.Commands.Auth;
using TeamTrain.Application.DTOs.SaaS.Auth;
using TeamTrain.Application.Interfaces.SaaS.Auth;

namespace TeamTrain.Application.CQRS.SaaS.Handlers.Auth;

public class RefreshTokenClientCommandHandler(IAuthClientService authService) : IRequestHandler<RefreshTokenClientCommand, ServiceResponse<AuthClientResult>>
{
    public async Task<ServiceResponse<AuthClientResult>> Handle(RefreshTokenClientCommand request, CancellationToken cancellationToken)
    {
        return await authService.RefreshTokenAsync(request.RefreshToken);
    }
}