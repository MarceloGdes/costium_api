using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Costium.Domain.Models;
public class ExpenseType
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Ulid Id { get; set; } = Ulid.NewUlid();

    [Required]
    [StringLength(40)]
    public string Description { get; set; }

    [Required]
    public Ulid UserId { get; set; }

    //[ForeignKey(nameof(UserId))]
    //public required User User { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ExpenseType(string description, Ulid userId)
    {
        Description = description;
        UserId = userId;
    }
}
