using Costium.Domain.Dtos;

namespace Costium.Domain.Interfaces;
public interface IAuthCommand
{
    public Task<string> AuthenticateAsync(LoginRequestDto dto);
    public Task<int> ResgisterAsync(RegisterRequestDTO dto);
}
