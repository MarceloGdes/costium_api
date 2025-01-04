using Costium.Domain.Dtos;
using Costium.Domain.Interfaces;
using Costium.Domain.Models;
using Costium.Infra.Database.Context;
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

    public async void Delete(string userId)
    {
        throw new NotImplementedException();
    }

    public async Task<GetExpenseTypeDto> Get(string id, string userId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<GetExpenseTypeDto>> GetAll(string userId)
    {
        throw new NotImplementedException();
    }

    public async Task<string> Update(string userId)
    {
        throw new NotImplementedException();
    }
}

