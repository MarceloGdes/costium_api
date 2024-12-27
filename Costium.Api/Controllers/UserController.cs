using Costium.Domain.Dtos;
using Costium.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Costium.Api.Controllers;
[Route("api/v1/user")]
[ApiController]
public class UserController(IUserCommand userCommand) : ControllerBase
{
    private readonly IUserCommand _userCommand = userCommand;

    [HttpGet("/{userId}")]
    public IActionResult Get([FromRoute] Guid userId)
    {

        return Ok(_userCommand.GetUser(userId));
    }

    [HttpPost]
    public IActionResult Add([FromBody] AddUserDto dto)
    {
        _userCommand.AddUser(dto);
        return Ok(dto);
    }
}
