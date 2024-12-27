using Costium.Domain.Dtos;
using Costium.Domain.Models;

namespace Costium.Domain.Interfaces;
public interface IUserCommand
{
    int AddUser(AddUserDto dto);
    void UpdateUser(UpdateUserDto dto);
    User? GetUser(Guid id);
}
