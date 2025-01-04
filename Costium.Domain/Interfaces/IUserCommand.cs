using Costium.Domain.Dtos;
using Costium.Domain.Models;

namespace Costium.Domain.Interfaces;
public interface IUserCommand
{
    Task<int> AddUser(AddUserDto dto);
    void UpdateUser(UpdateUserDto dto);
    Task<User> GetUser(string id);
}
