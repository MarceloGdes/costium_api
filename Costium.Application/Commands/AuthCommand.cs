﻿using Costium.Domain.Dtos;
using Costium.Domain.Interfaces;
using Costium.Infra.Database.Context;
using Costium.Infra.Services;
using Microsoft.EntityFrameworkCore;

namespace Costium.Application.Commands;
public class AuthCommand(CostiumContext context, JwtTokenService jwtTokenService) : IAuthCommand
{
    private readonly CostiumContext _context = context;
    private readonly JwtTokenService _jwtTokenService = jwtTokenService;

    public async Task<string> Authenticate(LoginRequestDto dto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email) 
            ?? throw new UnauthorizedAccessException("Credenciais inválidas.");

        if (user.PasswordHash.Equals(dto.Password))
            return _jwtTokenService.GenerateToken(user.Id.ToString());

        throw new UnauthorizedAccessException("Credenciais inválidas.");
    }
}

