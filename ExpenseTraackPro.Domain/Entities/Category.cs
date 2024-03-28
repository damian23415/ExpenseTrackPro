using System.ComponentModel.DataAnnotations;

namespace ExpenseTraackPro.Domain.Entities;

public class Category
{
    [Key]
    public Guid CategoryId { get; set; }
    
    public string CategoryName { get; set; }
    
    //RelationShips
    public ICollection<Expense> Expenses { get; set; }
}