using Costium.Domain.Dtos;
using Costium.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Costium.Api.Controllers.v1;
[Route("api/v{version:apiVersion}/auth")]
[ApiVersion("1.0")]
[ApiController]
public class AuthController(IAuthCommand authCommand) : ControllerBase
{
    private readonly IAuthCommand _authCommand = authCommand;

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
    {
        var token = await _authCommand.AuthenticateAsync(dto);
        return Ok(new { Token = token });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDTO dto)
    {
        return await _authCommand.ResgisterAsync(dto) >= 1 
            ? Ok() 
            : StatusCode(
                StatusCodes.Status500InternalServerError,
                "Erro inesperado ao realizar a criação de conta. Por gentileza, tente novamente mais tarde.");
    }
}
