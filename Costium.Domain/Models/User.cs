using System.ComponentModel.DataAnnotations;

namespace Costium.Domain.Models;

public class User
{
    [Key] // Define a chave primária
    public Guid Id { get; set; }

    [Required]
    [StringLength(60)]
    public required string Name { get; set; }

    [Required]
    [StringLength(255)]
    public required string Email { get; set; }

    [Required]
    [StringLength(255)]
    public required string PasswordHash { get; set; }

    // Define o valor padrão como a data atual
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
