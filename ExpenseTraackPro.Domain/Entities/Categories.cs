using System.ComponentModel.DataAnnotations;

namespace ExpenseTraackPro.Domain.Entities;

public class Categories
{
    [Key]
    public Guid CategoryId { get; set; }
    
    public string CategoryName { get; set; }
    
    //RelationShips
    public ICollection<Expenses> Expenses { get; set; }
}