using ExpenseTraackPro.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace ExpenseTraackPro.Domain.Entities.Identity;

public class ApplicationUser : IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    //RelationShips
    public ICollection<Expense> Expenses { get; set; }
}