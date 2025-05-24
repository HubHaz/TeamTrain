using MediatR;
using TeamTrain.Application.Common.Models;
using TeamTrain.Application.DTOs.Tenant.Auth;

namespace TeamTrain.Application.CQRS.Tenant.Commands.Auth;

public class LoginCommand(LoginDto dto) : IRequest<ServiceResponse<AuthResult>>
{
    public LoginDto LoginDto { get; set; } = dto;
}