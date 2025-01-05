using Costium.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Costium.Domain.Dtos;
public class GetExpenseTypeDto
{
    public required Ulid Id { get; set; } 
    public required string Description { get; set; }
    public DateTime CreatedAt { get; set; }
}
