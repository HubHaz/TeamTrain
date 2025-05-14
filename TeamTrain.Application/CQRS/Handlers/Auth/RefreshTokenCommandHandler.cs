using MediatR;
using TeamTrain.Application.Common.Models;
using TeamTrain.Application.CQRS.Commands.Auth;
using TeamTrain.Application.DTOs.Auth;
using TeamTrain.Application.Interfaces.Auth;

namespace TeamTrain.Application.CQRS.Handlers.Auth;

public class RefreshTokenCommandHandler(IAuthService authService) : IRequestHandler<RefreshTokenCommand, ServiceResponse<AuthResult>>
{
    public async Task<ServiceResponse<AuthResult>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        return await authService.RefreshTokenAsync(request.RefreshToken);
    }
}