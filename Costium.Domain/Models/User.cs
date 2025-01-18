using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Costium.Domain.Models;

public class User
{
    [Key] // Define a chave primária
    [DatabaseGenerated(DatabaseGeneratedOption.None)] //Chave gerada pelo código.
    public Ulid Id { get; set; } = Ulid.NewUlid();

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
    public DateTime CreatedAt { get; } = DateTime.UtcNow;

    public User(){}
}
