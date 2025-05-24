using MediatR;
using TeamTrain.Application.Common.Models;
using TeamTrain.Application.DTOs.SaaS.Auth;

namespace TeamTrain.Application.CQRS.SaaS.Commands.Auth;

public class RegisterClientCommand(RegisterClientDto registerDto) : IRequest<ServiceResponse<AuthClientResult>>
{
    public RegisterClientDto RegisterDto { get; } = registerDto;
}