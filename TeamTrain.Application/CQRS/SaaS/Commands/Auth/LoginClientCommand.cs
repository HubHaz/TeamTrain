using MediatR;
using TeamTrain.Application.Common.Models;
using TeamTrain.Application.DTOs.SaaS.Auth;

namespace TeamTrain.Application.CQRS.SaaS.Commands.Auth;

public class LoginClientCommand(LoginClientDto dto) : IRequest<ServiceResponse<AuthClientResult>>
{
    public LoginClientDto LoginDto { get; set; } = dto;
}