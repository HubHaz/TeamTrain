using MediatR;
using TeamTrain.Application.Common.Models;
using TeamTrain.Application.DTOs.Tenants.Auth;

namespace TeamTrain.Application.CQRS.Tenants.Commands.Auth;

public class LoginCommand(LoginDto dto) : IRequest<ServiceResponse<AuthResult>>
{
    public LoginDto LoginDto { get; set; } = dto;
}