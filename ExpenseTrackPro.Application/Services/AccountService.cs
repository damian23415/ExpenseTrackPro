using AutoMapper;
using ExpenseTraackPro.Domain.Entities.Identity;
using ExpenseTrackPro.Application.DTOs.Auth;
using ExpenseTrackPro.Application.Interfaces;
using ExpenseTrackPro.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExpenseTrackPro.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AccountService(UserManager<ApplicationUser> userManager, IConfiguration configuration, IMapper mapper)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<RegistrationResponseDTO> RegisterUser(UserRegisterDTO userRegisterDTO)
        {
            var existingUser = await _userManager.FindByEmailAsync(userRegisterDTO.Email);

            if (existingUser != null)
                throw new Exception("User with this email already exists.");

            var user = new ApplicationUser
            {
                UserName = userRegisterDTO.UserName,
                Email = userRegisterDTO.Email,
                FirstName = userRegisterDTO.FirstName,
                LastName = userRegisterDTO.LastName,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, userRegisterDTO.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Roles.Basic.ToString());

                return new RegistrationResponseDTO
                {
                    UserId = user.Id,
                    Message = "User registered successfully."
                };
            }

            throw new Exception("Error occurred during user registration.");
        }

        public async Task<TokenDTO> Authenticate(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);

            if (user == null)
                user = await _userManager.FindByNameAsync(loginDTO.Email);
            
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDTO.Password))
                throw new UnauthorizedAccessException("Invalid email or password.");
            
            var token = await GenerateToken(user);

            return new TokenDTO
            {
                Token = token,
                Message = "Authentication successful"
            };
        }

        public async Task<UserEditDTO> EditUser(UserEditDTO userEditDTO)
        {
            var user = await _userManager.FindByEmailAsync(userEditDTO.Email);

            if (user == null)
                throw new KeyNotFoundException("User not found");

            _mapper.Map(userEditDTO, user);

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
                throw new InvalidOperationException("Failed to update user");

            return _mapper.Map<UserEditDTO>(user);
        }

        private async Task<string> GenerateToken(ApplicationUser user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id.ToString()),
            };

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTSettings:Key"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _configuration["JWTSettings:Issuer"],
                audience: _configuration["JWTSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration["JWTSettings:DurationInMinutes"])),
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}
