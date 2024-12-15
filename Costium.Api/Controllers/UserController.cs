using Costium.Domain.Dtos;
using Costium.Domain.Interfaces;
using Costium.Infra.Database.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Costium.Api.Controllers;
[Route("api/v1/user")]
[ApiController]
public class UserController(IUserCommand userCommand) : ControllerBase
{
    private readonly IUserCommand _userCommand = userCommand;

    [HttpPost]
    public IActionResult Add([FromBody] AddUserDto dto)
    {
        _userCommand.AddUser(dto);
        return Ok(dto);
    }
}
