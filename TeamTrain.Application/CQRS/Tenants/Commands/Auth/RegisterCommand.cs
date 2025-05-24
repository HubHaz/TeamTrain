using MediatR;
using TeamTrain.Application.Common.Models;
using TeamTrain.Application.DTOs.Tenants.Auth;

namespace TeamTrain.Application.CQRS.Tenants.Commands.Auth;

public class RegisterCommand(RegisterDto registerDto) : IRequest<ServiceResponse<AuthResult>>
{
    public RegisterDto RegisterDto { get; } = registerDto;
}