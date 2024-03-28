using ExpenseTrackPro.Application.DTOs;
using ExpenseTrackPro.Application.DTOs.Auth;
using ExpenseTrackPro.Application.DTOs.User;
using ExpenseTrackPro.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackProV2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }
    
    [HttpPost("Authentication")]
    public async Task<IActionResult> Authentication(AuthenticationRequest authenticationModel, CancellationToken cancellationToken)
    {
        var result = await _accountService.Authenticate(authenticationModel);

        return Ok(result);
    }

    [HttpPost("RegisterUser")]
    public async Task<IActionResult> RegisterUser(UserRegisterRequest userRegisterModel, CancellationToken cancellationToken)
    {
        var result = await _accountService.RegisterUser(userRegisterModel);

        return Ok(result);
    }

    [Authorize]
    [HttpPost("EditUser")]
    public async Task<IActionResult> EditUser(UserEditRequest userEditModel, CancellationToken cancellationToken)
    {
        var result = await _accountService.EditUser(userEditModel);

        return Ok(result);
    }
}