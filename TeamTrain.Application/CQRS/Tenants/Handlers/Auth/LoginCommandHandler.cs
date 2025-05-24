using MediatR;
using TeamTrain.Application.Common.Models;
using TeamTrain.Application.CQRS.SaaS.Commands.Auth;
using TeamTrain.Application.CQRS.Tenants.Commands.Auth;
using TeamTrain.Application.DTOs.Tenants.Auth;
using TeamTrain.Application.Interfaces.Tenants.Auth;

namespace TeamTrain.Application.CQRS.Tenants.Handlers.Auth;

public class LoginCommandHandler(IAuthService authService) : IRequestHandler<LoginCommand, ServiceResponse<AuthResult>>
{
    public async Task<ServiceResponse<AuthResult>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        return await authService.LoginAsync(request.LoginDto);
    }
}