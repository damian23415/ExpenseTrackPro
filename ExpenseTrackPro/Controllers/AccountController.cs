﻿using Application.DTOs;
using Application.Interfaces;
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

    [HttpPost("RegisterUser")]
    public async Task<IActionResult> RegisterUser(RegisterRequest registerModel, CancellationToken cancellationToken)
    {
        var result = await _accountService.RegisterUser(registerModel);

        return Ok(result);
    }
}