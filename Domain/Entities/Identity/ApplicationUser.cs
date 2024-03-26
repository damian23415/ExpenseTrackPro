using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Identity;

public class ApplicationUser : IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    
    //RelationShips
    public ICollection<Expenses> Expenses { get; set; }
}