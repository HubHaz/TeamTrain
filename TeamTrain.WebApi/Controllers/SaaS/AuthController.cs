using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamTrain.Application.CQRS.SaaS.Commands.Auth;
using TeamTrain.Application.DTOs.SaaS.Auth;

namespace TeamTrain.WebApi.Controllers.SaaS;

[ApiController]
[Route("[controller]")]
public class AuthController(ISender sender) : BaseController
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterClientDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await sender.Send(new RegisterClientCommand(dto));
        return FromServiceResponse(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginClientDto dto)
    {
        var result = await sender.Send(new LoginClientCommand(dto));
        return FromServiceResponse(result);
    }

    [Authorize]
    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenClientDto dto)
    {
        var result = await sender.Send(new RefreshTokenClientCommand(dto.Token));
        return FromServiceResponse(result);
    }
}