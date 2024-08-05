using ExpenseTrackPro.Application.DTOs;
using ExpenseTrackPro.Application.DTOs.Auth;

namespace ExpenseTrackPro.Application.Interfaces;

public interface IAccountService
{
    Task<RegistrationResponseDTO> RegisterUser(UserRegisterDTO userRegisterDTO);
    Task<TokenDTO> Authenticate(LoginDTO request);
    Task<UserEditDTO> EditUser(UserEditDTO userEditRequest);
}