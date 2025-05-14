using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TeamTrain.Application.Common.Models;

namespace TeamTrain.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    protected Guid UserId => Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var id) ? id : Guid.Empty;
    protected string? UserEmail => User.FindFirstValue(ClaimTypes.Email);
    protected string? UserRole => User.FindFirstValue(ClaimTypes.Role);

    protected bool IsInRole(string role) => User.IsInRole(role);

    protected IActionResult FromServiceResponse<T>(ServiceResponse<T> response)
    {
        if (response.Success)
            return Ok(response);

        return BadRequest(response);
    }
}