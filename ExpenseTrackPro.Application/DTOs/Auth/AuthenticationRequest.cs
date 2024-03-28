using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackPro.Application.DTOs.Auth;

public class AuthenticationRequest
{
    [Required]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
}