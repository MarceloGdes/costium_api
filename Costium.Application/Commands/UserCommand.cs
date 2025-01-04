using Costium.Domain.Dtos;
using Costium.Domain.Interfaces;
using Costium.Domain.Models;
using Costium.Infra.Database.Context;
using Costium.Infra.Utils;
using Microsoft.EntityFrameworkCore;

namespace Costium.Application.Commands;
public class UserCommand(CostiumContext context) : IUserCommand
{

    private readonly CostiumContext _context = context;

    public Task<int> AddUser(AddUserDto dto)
    {
        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            PasswordHash = dto.Password
        };

        _context.Users.Add(user);
        return _context.SaveChangesAsync();

    }

    public async Task<User> GetUser(string id)
    {

        User user = await _context.Users.FirstOrDefaultAsync(u => u.Id == Ulid.Parse(id)) 
            ?? throw new NullReferenceException();
        return user;
    }

    public void UpdateUser(UpdateUserDto dto)
    {
        throw new NotImplementedException();
    }
}
