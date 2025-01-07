using Costium.Domain.Dtos;
using Costium.Domain.Interfaces;
using Costium.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Costium.Api.Controllers;
[Route("api/v1/expense-types")]
[ApiController]
public class ExpenseTypeController(IExpenseTypeCommand expenseTypeCommand) : ControllerBase
{
    private readonly IExpenseTypeCommand _command = expenseTypeCommand;

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddExpenseType([FromBody] AddExpenseTypeDto dto)
    {
        var userIdClaim = User.FindFirst("userId")?.Value;
        if (userIdClaim == null) return Unauthorized("Não autorizado, realize login novamente.");

        var expenseTypeId = await _command.Add(dto, userIdClaim);
        var resourseUrl = Url.Action(nameof(GetExpenseType), new { id = expenseTypeId });

        return Created(resourseUrl, new { id = expenseTypeId });
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetExpenseType([FromRoute] string id)
    {
        var userId = User.FindFirst("userId")?.Value;
        return userId == null 
            ? Unauthorized("Não autorizado, realize login novamente.") 
            : Ok(await _command.Get(id, userId));
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetExpenseTypes([FromQuery] int pageNumber, int pageQuantity)
    {
        var userId = User.FindFirst("userId")?.Value;
        return userId == null
            ? throw new HttpRequestException("Não autorizado, realize login novamente.", null, System.Net.HttpStatusCode.Unauthorized)
            : Ok(await _command.GetAll(userId, pageNumber, pageQuantity));
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateExpenseType(
        [FromRoute] string id, [FromBody] UpdateExpenseTypeDto dto)
    {
        var userId = User.FindFirst("userId")?.Value;
        if (userId == null)
            return Unauthorized("Não autorizado, realize login novamente.");

        return await _command.Update(dto, id, userId) >= 1
            ? NoContent()
            : StatusCode(
                StatusCodes.Status500InternalServerError, 
                "Erro inesperado ao atualizar o tipo de despesa. Tente novamente mais tardel");
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExpenseType([FromRoute] string id)
    {
        var userId = User.FindFirst("userId")?.Value;
        if (userId == null) 
            return Unauthorized("Não autorizado, realize login novamente.");

        return await _command.Delete(id, userId) >= 1
            ? NoContent()
            : StatusCode(
                StatusCodes.Status500InternalServerError,
                "Erro inesperado ao atualizar o tipo de despesa. Tente novamente mais tarde.");
    }

}
