using System.ComponentModel.DataAnnotations;

namespace Costium.Domain.Dtos;
public class AddUserDto
{
    [Required]
    [StringLength(60)]
    public required string Name { get; set; }

    [Required]
    [StringLength(255)]
    public required string Email { get; set; }

    [Required]
    [StringLength(255)]
    public required string Password { get; set; }

    public AddUserDto(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
    }
}
