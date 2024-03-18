using Application.DTOs;
using Application.Wrappers;

namespace Application.Interfaces;

public interface IAccountService
{
    Task<ApiResponse<Guid>> RegisterUser(UserRegisterRequest userRegisterRequest);
    Task<ApiResponse<AuthenticationResponse>> Authenticate(AuthenticationRequest request);
    Task<ApiResponse<Guid>> EditUser(UserEditRequest userEditRequest);
}