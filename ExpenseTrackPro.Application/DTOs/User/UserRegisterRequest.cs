using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackPro.Application.DTOs.User;

public class UserRegisterRequest
{
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    [Required]
    public string Gender { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    public string UserName { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    [Required]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
}