using Costium.Domain.Dtos;
using Costium.Domain.Interfaces;
using Costium.Domain.Models;
using Costium.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Costium.Application.Commands;
public class ExpenseTypeCommand(CostiumContext context, IUserCommand userCommand) : IExpenseTypeCommand
{
    private readonly CostiumContext _context = context;
    private readonly IUserCommand _userCommand = userCommand;

    public async Task<string> Add(AddExpenseTypeDto dto, string userId)
    {   
        if(dto.Description.IsNullOrEmpty()) throw new ArgumentNullException(nameof(dto.Description));

        var ExpenseType = new ExpenseType(dto.Description, Ulid.Parse(userId));

        _context.ExpenseType.Add(ExpenseType);
        await _context.SaveChangesAsync();

        return ExpenseType.Id.ToString();
    }

    public async Task<GetExpenseTypeDto> Get(string expenseTypeId, string userId)
    {   
        var expenseType = await _context.ExpenseType.FirstOrDefaultAsync(et => 
            et.Id == Ulid.Parse(expenseTypeId) && et.UserId == Ulid.Parse(userId)) ?? throw new KeyNotFoundException(
                "Tipo de despesa não encontrado.");

        var expenseTypeDto = new GetExpenseTypeDto
        {
            Description = expenseType.Description,
            Id = expenseType.Id,
            CreatedAt = expenseType.CreatedAt
        };

        return expenseTypeDto;
    }

    //Aplicado paginação
    public async Task<List<GetExpenseTypeDto>> GetAll(string userId, int pageNumber, int pageQuantity)
    {
        var expenseTypeListDto = new List<GetExpenseTypeDto>();

        expenseTypeListDto = await _context.ExpenseType
            .Where(et => et.UserId == Ulid.Parse(userId))
            .Select(et => new GetExpenseTypeDto
            {
                Id = et.Id,
                Description = et.Description,
                CreatedAt = et.CreatedAt
            })
            .Skip(pageNumber * pageQuantity) // O método .Skip() ignora os primeiros count registros da consulta.
            .Take(pageQuantity) //Quantidade de registros retornados
            .ToListAsync();

        return expenseTypeListDto.Count > 0
            ? expenseTypeListDto
            : throw new KeyNotFoundException("Não foi encontrado tipos de despesa cadastradas para seu usuário.");
    }

    public async Task<int> Update(UpdateExpenseTypeDto dto, string expenseTypeId, string userId)
    {
        var expenseType = await _context.ExpenseType.FirstOrDefaultAsync(et =>
            et.Id == Ulid.Parse(expenseTypeId) && et.UserId == Ulid.Parse(userId))
            ?? throw new KeyNotFoundException(
                "Um erro aconteceu ao tentar alterar um tipo de despesa: Tipo de despesa não encontrado.");

        expenseType.Description = dto.Description;

        _context.ExpenseType.Update(expenseType);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> Delete(string expenseTypeId, string userId)
    {
        var expenseType = await _context.ExpenseType.FirstOrDefaultAsync(et =>
            et.Id == Ulid.Parse(expenseTypeId) && et.UserId == Ulid.Parse(userId)) ?? throw new KeyNotFoundException(
                "Um erro aconteceu ao tentar excuir um tipo de despesa: Tipo de despesa não encontrado.");

        _context.ExpenseType.Remove(expenseType);
        return await _context.SaveChangesAsync();
    }

}

