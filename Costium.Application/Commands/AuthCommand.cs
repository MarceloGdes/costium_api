using Costium.Domain.Dtos;
using Costium.Domain.Interfaces;
using Costium.Domain.Models;
using Costium.Infra.Database.Context;
using Costium.Infra.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Costium.Application.Commands;
public class AuthCommand(CostiumContext context, JwtTokenService jwtTokenService) : IAuthCommand
{
    private readonly CostiumContext _context = context;
    private readonly JwtTokenService _jwtTokenService = jwtTokenService;
    private readonly PasswordHasher<User> _passwordHasher = new ();

    public async Task<string> AuthenticateAsync(LoginRequestDto dto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email)
            ?? throw new HttpRequestException("E-mail ou senha incorreta", null, System.Net.HttpStatusCode.Unauthorized);

        if (_passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password) == PasswordVerificationResult.Failed)
            throw new HttpRequestException("E-mail ou senha incorreta.", null, System.Net.HttpStatusCode.Unauthorized);

        return _jwtTokenService.GenerateToken(user.Id.ToString());
    }

    public async Task<int> ResgisterAsync(RegisterRequestDTO dto)
    {
        if(await _context.Users.AnyAsync(u => u.Email == dto.Email))
            throw new HttpRequestException("Email já registrado", null, 
                System.Net.HttpStatusCode.BadRequest);

        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            PasswordHash = dto.Password
        };
        user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);

        _context.Users.Add(user);
        return await _context.SaveChangesAsync();
    }
}

