using System.ComponentModel.DataAnnotations;

namespace Costium.Domain.Dtos;
public class UpdateUserDto
{

    [StringLength(60)]
    public string Name { get; set; }

    public UpdateUserDto(string name)
    {
        Name = name;
    }
}
