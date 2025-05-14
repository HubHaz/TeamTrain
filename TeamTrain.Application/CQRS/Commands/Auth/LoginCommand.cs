using MediatR;
using TeamTrain.Application.Common.Models;
using TeamTrain.Application.DTOs.Auth;

namespace TeamTrain.Application.CQRS.Commands.Auth;

public class LoginCommand(LoginDto dto) : IRequest<ServiceResponse<AuthResult>>
{
    public LoginDto LoginDto { get; set; } = dto;
}