using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using ExpenseTraackPro.Domain.Entities.Identity;
using ExpenseTrackPro.Application.DTOs;
using ExpenseTrackPro.Application.Enums;
using ExpenseTrackPro.Application.Exceptions;
using ExpenseTrackPro.Application.Interfaces;
using ExpenseTrackPro.Application.Wrappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ExpenseTrackPro.Infrastructure.SharedServices;

public class AccountService : IAccountService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IConfiguration _configuration;
    
    public AccountService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<ApiResponse<Guid>> RegisterUser(UserRegisterRequest userRegisterRequest)
    {
        var user = await _userManager.FindByEmailAsync(userRegisterRequest.Email);

        if (user != null)
            return new ApiResponse<Guid>(HttpStatusCode.Conflict, ErrorCode.AccountWithEmailAlreadyExist);

        var userModel = new ApplicationUser()
        {
            UserName = userRegisterRequest.UserName,
            Email = userRegisterRequest.Email,
            FirstName = userRegisterRequest.FirstName,
            LastName = userRegisterRequest.LastName,
            Gender = userRegisterRequest.Gender,
            EmailConfirmed = true,
            PhoneNumberConfirmed = true
        };

        var result = await _userManager.CreateAsync(userModel, userRegisterRequest.Password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(userModel, Roles.Basic.ToString());
            return new ApiResponse<Guid>(userModel.Id, "User register successfuly");
        }
        
        throw new ApiException(result.Errors.ToString());
    }

    public async Task<ApiResponse<AuthenticationResponse>> Authenticate(AuthenticationRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
            return new ApiResponse<AuthenticationResponse>(HttpStatusCode.BadRequest, ErrorCode.AccountWithEmailNotExist);

        var succeded = await _userManager.CheckPasswordAsync(user, request.Password);
        
        if (!succeded)
            return new ApiResponse<AuthenticationResponse>(HttpStatusCode.Unauthorized, ErrorCode.InvalidEmailOrPassword);

        var jwtSecurity = await GenerateToken(user);
        var authenticationResponse = new AuthenticationResponse();

        authenticationResponse.Id = user.Id;
        authenticationResponse.UserName = user.UserName;
        authenticationResponse.Email = user.Email;
        authenticationResponse.FirstName = user.FirstName;
        authenticationResponse.LastName = user.LastName;
        authenticationResponse.IsVerified = user.EmailConfirmed;

        var roles = await _userManager.GetRolesAsync(user);

        authenticationResponse.Roles = roles.ToList();
        authenticationResponse.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurity);

        return new ApiResponse<AuthenticationResponse>(authenticationResponse, "User authenticated");
    }

    public async Task<ApiResponse<Guid>> EditUser(UserEditRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
            return new ApiResponse<Guid>(HttpStatusCode.NotFound, ErrorCode.AccountWithEmailNotExist);

        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.UserName = request.UserName;
        user.Email = request.Email;
    
        var result = await _userManager.UpdateAsync(user);

        if (!result.Succeeded)
            throw new ApiException(result.Errors.ToString());

        return new ApiResponse<Guid>(user.Id, "User edited succesfully");
    }

    private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
    {
        var dbClaim = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);

        var roleClaims = new List<Claim>();

        for (int i = 0; i < roles.Count; i++)
        {
            roleClaims.Add(new Claim("roles", roles[i]));
        }
        
        var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id.ToString()),
            }
            .Union(dbClaim)
            .Union(roleClaims);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _configuration["JwtSettings:Issuer"],
            audience: _configuration["JwtSettings:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration["JwtSettings:DurationInMinutes"])),
            signingCredentials: signingCredentials);
        return jwtSecurityToken;
    }
}