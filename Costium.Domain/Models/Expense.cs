
namespace Costium.Domain.Models;
public class Expense : Base
{
    public string description { get; set; }
    public double totalValue { get; set; }
    public bool paid { get; set; }

}
