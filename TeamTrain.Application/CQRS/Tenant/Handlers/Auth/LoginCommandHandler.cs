using MediatR;
using TeamTrain.Application.Common.Models;
using TeamTrain.Application.CQRS.SaaS.Commands.Auth;
using TeamTrain.Application.CQRS.Tenant.Commands.Auth;
using TeamTrain.Application.DTOs.Tenant.Auth;
using TeamTrain.Application.Interfaces.Tenant.Auth;

namespace TeamTrain.Application.CQRS.Tenant.Handlers.Auth;

public class LoginCommandHandler(IAuthService authService) : IRequestHandler<LoginCommand, ServiceResponse<AuthResult>>
{
    public async Task<ServiceResponse<AuthResult>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        return await authService.LoginAsync(request.LoginDto);
    }
}