﻿using Application.DTOs;
using Application.Wrappers;

namespace Application.Interfaces;

public interface IAccountService
{
    Task<ApiResponse<Guid>> RegisterUser(RegisterRequest registerRequest);
    Task<ApiResponse<AuthenticationResponse>> Authenticate(AuthenticationRequest request);
}