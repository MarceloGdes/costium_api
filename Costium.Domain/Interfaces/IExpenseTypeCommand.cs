using Costium.Domain.Dtos;

namespace Costium.Domain.Interfaces;
public interface IExpenseTypeCommand
{
    Task<string> Add(AddExpenseTypeDto dto, string userId);
    void Delete(string userId);
    Task<string> Update(string userId);
    Task<GetExpenseTypeDto> Get(string id, string userId);
    Task<List<GetExpenseTypeDto>> GetAll(string userId);
}

