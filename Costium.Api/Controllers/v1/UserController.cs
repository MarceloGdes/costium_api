using Costium.Domain.Dtos;
using Costium.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Costium.Api.Controllers.v1;
[Route("api/v{version:apiVersion}/user")]
[ApiVersion("1.0")]
[ApiController]
public class UserController(IUserCommand userCommand) : ControllerBase
{
    private readonly IUserCommand _userCommand = userCommand;

    [Authorize]
    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] string id)
    {

        return Ok(_userCommand.GetUser(id));
    }

    [HttpPost]
    public IActionResult Add([FromBody] AddUserDto dto)
    {
        _userCommand.AddUser(dto);
        return Ok(dto);
    }
}
