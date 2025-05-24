using MediatR;
using TeamTrain.Application.Common.Models;
using TeamTrain.Application.CQRS.SaaS.Commands.Auth;
using TeamTrain.Application.Interfaces.SaaS.Auth;

namespace TeamTrain.Application.CQRS.SaaS.Handlers.Auth;

public class RegisterClientCommandHandler(IAuthClientService authService) : IRequestHandler<RegisterClientCommand, ServiceResponse>
{
    public async Task<ServiceResponse> Handle(RegisterClientCommand request, CancellationToken cancellationToken)
    {
        return await authService.RegisterAsync(request.RegisterDto);
    }
}