using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamTrain.Application.CQRS.Commands.Auth;
using TeamTrain.Application.DTOs.Auth;

namespace TeamTrain.WebApi.Controllers;

public class AuthController(ISender sender) : BaseController
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await sender.Send(new RegisterCommand(dto));
        return FromServiceResponse(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var result = await sender.Send(new LoginCommand(dto));
        return FromServiceResponse(result);
    }

    [Authorize]
    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto dto)
    {
        var result = await sender.Send(new RefreshTokenCommand(dto.Token));
        return FromServiceResponse(result);
    }
}