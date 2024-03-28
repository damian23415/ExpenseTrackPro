using ExpenseTrackPro.Application.DTOs;
using ExpenseTrackPro.Application.DTOs.Auth;
using ExpenseTrackPro.Application.DTOs.User;
using ExpenseTrackPro.Application.Wrappers;

namespace ExpenseTrackPro.Infrastructure.Services.Interfaces;

public interface IAccountService
{
    Task<ApiResponse<Guid>> RegisterUser(UserRegisterRequest userRegisterRequest);
    Task<ApiResponse<AuthenticationResponse>> Authenticate(AuthenticationRequest request);
    Task<ApiResponse<Guid>> EditUser(UserEditRequest userEditRequest);
}