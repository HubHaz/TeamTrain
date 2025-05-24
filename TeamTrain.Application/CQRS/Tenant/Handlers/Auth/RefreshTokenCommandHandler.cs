using MediatR;
using TeamTrain.Application.Common.Models;
using TeamTrain.Application.CQRS.SaaS.Commands.Auth;
using TeamTrain.Application.CQRS.Tenant.Commands.Auth;
using TeamTrain.Application.DTOs.Tenant.Auth;
using TeamTrain.Application.Interfaces.Tenant.Auth;

namespace TeamTrain.Application.CQRS.Tenant.Handlers.Auth;

public class RefreshTokenCommandHandler(IAuthService authService) : IRequestHandler<RefreshTokenCommand, ServiceResponse<AuthResult>>
{
    public async Task<ServiceResponse<AuthResult>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        return await authService.RefreshTokenAsync(request.RefreshToken);
    }
}