using MediatR;
using TeamTrain.Application.Common.Models;
using TeamTrain.Application.DTOs.SaaS.Auth;

namespace TeamTrain.Application.CQRS.SaaS.Commands.Auth;

public class RegisterClientCommand(RegisterClientDto registerDto) : IRequest<ServiceResponse>
{
    public RegisterClientDto RegisterDto { get; } = registerDto;
}