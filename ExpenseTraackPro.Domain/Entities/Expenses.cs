using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExpenseTraackPro.Domain.Entities.Identity;

namespace ExpenseTraackPro.Domain.Entities;

public class Expenses
{
    [Key]
    public Guid IncomeId {get; set;}
    
    [Required]
    public Guid UserId { get; set; }
    
    [Required]
    public decimal Amount { get; set; }
    
    public string? Description { get; set; }
    
    [Required]
    public Guid CategoryId { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    //RelationShip
    [ForeignKey("CategoryId")]
    public Categories Categories { get; set; }
    
    [ForeignKey("UserId")]
    public ApplicationUser ApplicationUsers { get; set; }
}
