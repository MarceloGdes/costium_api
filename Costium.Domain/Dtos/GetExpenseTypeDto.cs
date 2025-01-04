using Costium.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Costium.Domain.Dtos;
public class GetExpenseTypeDto
{
    public required string Id { get; set; } 
    public required string Name { get; set; }
    public DateTime CreatedAt { get; set; }
}
