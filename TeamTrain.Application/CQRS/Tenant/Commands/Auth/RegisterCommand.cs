using MediatR;
using TeamTrain.Application.Common.Models;
using TeamTrain.Application.DTOs.Tenant.Auth;

namespace TeamTrain.Application.CQRS.Tenant.Commands.Auth;

public class RegisterCommand(RegisterDto registerDto) : IRequest<ServiceResponse<AuthResult>>
{
    public RegisterDto RegisterDto { get; } = registerDto;
}