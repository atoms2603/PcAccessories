using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PcAccessories.Dtos.UsersDto;
using PcAccessories.Entities.Entities;
using PcAccessories.Services.CMS.UserService;
using PcAccessories.Ultilities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.WebAPI.Controllers.UserAPI
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : APIControllerBase
    {
        #region Private fields

        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IConfiguration _config;

        #endregion

        #region Constructor

        public UserController(IUserService userService,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<Role> roleManager,
            IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
            _userService = userService;
        }

        #endregion

        #region API Controllers

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            if (request == null || request.Username.IsNullOrEmpty() || 
                request.Password.IsNullOrEmpty())
            {
                return BadRequest(ErrorMessages.InvalidRequest);
            }

            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null) return BadRequest(ErrorMessages.User_NotFound);

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            if (!result.Succeeded)
            {
                return BadRequest(ErrorMessages.User_WrongPassword);
            }

            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>()
            {
                new Claim("Email",user.Email),
                new Claim("Name",user.Name),
                new Claim("UserRole", string.Join(";",roles)),
                new Claim("UserName", request.Username),
                new Claim("UserId", user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Authentication:JwtBearer:SecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Authentication:JwtBearer:Issuer"],
                _config["Authentication:JwtBearer:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(int.Parse(_config["Authentication:JwtBearer:Expiration"])),
                signingCredentials: creds);

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            if (request == null || request.Username.IsNullOrEmpty() || request.ConfirmPassword.IsNullOrEmpty() || request.Email.IsNullOrEmpty() || request.DisplayName.IsNullOrEmpty() ||
                request.Password.IsNullOrEmpty())
            {
                return BadRequest(ErrorMessages.InvalidRequest);
            }

            if (await _userManager.FindByNameAsync(request.Username) != null)
                return BadRequest(ErrorMessages.User_UsernameHasTaken);

            if (await _userManager.FindByEmailAsync(request.Email) != null)
                return BadRequest(ErrorMessages.User_EmailHasTaken);

            if (await _userService.FindByPhoneNumber(request.PhoneNumber) != null)
                return BadRequest(ErrorMessages.User_PhoneNumberHasBeenUsed);

            if (!request.Password.Equals(request.ConfirmPassword))
            {
                return BadRequest(ErrorMessages.User_ConfirmPasswordNotMatch);
            }

            var user = new User()
            {
                Email = request.Email,
                Address = request.Address,
                UserName = request.Username,
                PhoneNumber = request.PhoneNumber,
                Name = request.DisplayName,
                Status = (byte)PcAccessoriesEnum.UserStatus.Active,
                Id = Guid.NewGuid(),
                CreatetionTime = DateTime.UtcNow
            };
            
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                return BadRequest(ErrorMessages.User_SignUpFailed);
            }

            return Ok(ErrorMessages.User_SignUpSuccess);
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetUser(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null) return BadRequest("Account does not exists.");


            return Ok(user);
        }

        #endregion
    }
}
