using Costium.Domain.Dtos;

namespace Costium.Domain.Interfaces;
public interface IAuthCommand
{
    public Task<string> Authenticate(LoginRequestDto dto);
}
