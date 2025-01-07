using Costium.Domain.Dtos;
using Costium.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Costium.Api.Controllers;
[Route("api/v1/auth")]
[ApiController]
public class AuthController(IAuthCommand authCommand) : ControllerBase
{
    private readonly IAuthCommand _authCommand = authCommand;

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
    {
        var token = await _authCommand.Authenticate(dto);
        return Ok(new { Token = token });
    }
}
