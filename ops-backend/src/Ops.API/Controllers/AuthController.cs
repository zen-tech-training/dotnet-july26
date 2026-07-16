using Microsoft.AspNetCore.Mvc;
using Ops.Application.DTOs.Auth;
using Ops.Application.Interfaces;

namespace Ops.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;

    public AuthController(IAuthService service)
    {
        _service = service;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(
        LoginRequestDto dto,
        CancellationToken cancellationToken)
    {
        var result = await _service.LoginAsync(
            dto,
            cancellationToken);

        return Ok(result);
    }
}