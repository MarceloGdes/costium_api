﻿using System.ComponentModel.DataAnnotations;

namespace Costium.Domain.Dtos;
public class RegisterRequestDTO
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}
