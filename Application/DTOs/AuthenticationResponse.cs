﻿namespace Application.DTOs;

public class AuthenticationResponse
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<string> Roles { get; set; }
    public bool IsVerified { get; set; }
    public string JWToken { get; set; }
}