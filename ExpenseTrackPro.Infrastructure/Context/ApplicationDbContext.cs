using ExpenseTraackPro.Domain.Entities;
using ExpenseTraackPro.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackPro.Infrastructure.Context;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    // public ApplicationDbContext() : base()
    // {
    //     
    // }
    
    public DbSet<Category> Category { get; set; }
    public DbSet<Expense> Expenses { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     
    // }
    //{
      //  optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=ExpenseTrackPro;Trusted_Connection=True;Encrypt=False");
    //}
}