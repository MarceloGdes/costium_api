using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Costium.Domain.Dtos;
using Costium.Domain.Interfaces;
using Costium.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Costium.Api.Controllers;
[Route("api/v1/expense-type")]
[ApiController]
public class ExpenseTypeController(IExpenseTypeCommand expenseTypeCommand) : ControllerBase
{
    IExpenseTypeCommand _command = expenseTypeCommand;

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddExpenseType([FromBody] AddExpenseTypeDto dto)
    {
        var userIdClaim = User.FindFirst("userId")?.Value;
        if (userIdClaim == null) return Unauthorized("Não autorizado, realize login novamente.");

        return Ok(await _command.Add(dto, userIdClaim.ToString()));
    }
}
