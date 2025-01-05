using Costium.Domain.Dtos;

namespace Costium.Domain.Interfaces;
public interface IExpenseTypeCommand
{
    Task<string> Add(AddExpenseTypeDto dto, string userId);
    Task<int> Delete(string expenseTypeId, string userId);
    Task<int> Update(UpdateExpenseTypeDto dto, string expenseTypeId, string userId);
    Task<GetExpenseTypeDto> Get(string expenseTypeId, string userId);
    Task<List<GetExpenseTypeDto>> GetAll(string userId);
}

