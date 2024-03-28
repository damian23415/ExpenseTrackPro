using ExpenseTrackPro.Application.DTOs;
using ExpenseTrackPro.Application.Wrappers;

namespace ExpenseTrackPro.Application.Interfaces;

public interface IAccountService
{
    Task<ApiResponse<Guid>> RegisterUser(UserRegisterRequest userRegisterRequest);
    Task<ApiResponse<AuthenticationResponse>> Authenticate(AuthenticationRequest request);
    Task<ApiResponse<Guid>> EditUser(UserEditRequest userEditRequest);
}