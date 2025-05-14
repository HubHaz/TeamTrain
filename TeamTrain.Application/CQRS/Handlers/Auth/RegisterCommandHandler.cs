using MediatR;
using TeamTrain.Application.Common.Models;
using TeamTrain.Application.CQRS.Commands.Auth;
using TeamTrain.Application.DTOs.Auth;
using TeamTrain.Application.Interfaces.Auth;

namespace TeamTrain.Application.CQRS.Handlers.Auth;

public class RegisterCommandHandler(IAuthService authService) : IRequestHandler<RegisterCommand, ServiceResponse<AuthResult>>
{
    public async Task<ServiceResponse<AuthResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        return await authService.RegisterAsync(request.RegisterDto);
    }
}