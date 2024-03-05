using Application.DTOs;
using Application.Enums;
using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using Microsoft.AspNetCore.Identity;
using Persistance.IdentityModels;

namespace Persistance.SharedServices;

public class AccountService : IAccountService
{
    private readonly UserManager<ApplicationUser> _userManager;
    
    public AccountService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<ApiResponse<Guid>> RegisterUser(RegisterRequest registerRequest)
    {
        var user = await _userManager.FindByEmailAsync(registerRequest.Email);

        if (user != null)
            throw new ApiException($"User already exist {registerRequest.Email}");

        var userModel = new ApplicationUser()
        {
            UserName = registerRequest.UserName,
            Email = registerRequest.Email,
            FirstName = registerRequest.FirstName,
            LastName = registerRequest.LastName,
            Gender = registerRequest.Gender,
            EmailConfirmed = true,
            PhoneNumberConfirmed = true
        };

        var result = await _userManager.CreateAsync(userModel, registerRequest.Password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(userModel, Roles.Basic.ToString());
            return new ApiResponse<Guid>(userModel.Id, "User register successfuly");
        }

        throw new ApiException(result.Errors.ToString());
    }
}