using MediatR;
using TeamTrain.Application.Common.Models;
using TeamTrain.Application.CQRS.Tenant.Commands.Auth;
using TeamTrain.Application.DTOs.Tenant.Auth;
using TeamTrain.Application.Interfaces.Tenant.Auth;

namespace TeamTrain.Application.CQRS.Tenant.Handlers.Auth;

public class RegisterCommandHandler(IAuthService authService) : IRequestHandler<RegisterCommand, ServiceResponse<AuthResult>>
{
    public async Task<ServiceResponse<AuthResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        return await authService.RegisterAsync(request.RegisterDto);
    }
}