using Costium.Domain.Dtos;
using Costium.Domain.Interfaces;
using Costium.Domain.Models;
using Costium.Infra.Database.Context;

namespace Costium.Application.Commands;
public class UserCommand(CostiumContext context) : IUserCommand
{

    private readonly CostiumContext _context = context;

    public int AddUser(AddUserDto dto)
    {
        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            PasswordHash = dto.Password
        };

        _context.Users.Add(user);
        return _context.SaveChanges();
    }

    public User? GetUser(string id)
    {
        User? user = _context.Users.Find(Ulid.Parse(id));
        return user;
    }

    public void UpdateUser(UpdateUserDto dto)
    {
        throw new NotImplementedException();
    }
}
