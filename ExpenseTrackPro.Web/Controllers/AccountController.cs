using ExpenseTrackPro.Application.DTOs.Auth;
using ExpenseTrackPro.Application.Interfaces;
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
    
    [HttpPost("authenticate")]
    public async Task<IActionResult> Authenticate([FromBody] LoginDTO request, CancellationToken cancellationToken)
    {
        try
        {
            var tokenResponse = await _accountService.Authenticate(request);
            return Ok(tokenResponse);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterDTO userRegisterDTO, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _accountService.RegisterUser(userRegisterDTO);
            return CreatedAtAction(nameof(Register), new { id = response.UserId }, response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    [Authorize]
    [HttpPost("edit")]
    public async Task<IActionResult> Edit([FromBody] UserEditDTO userEditDTO, CancellationToken cancellationToken)
    {
        try
        {
            var updatedUser = await _accountService.EditUser(userEditDTO);
            return Ok(updatedUser);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}