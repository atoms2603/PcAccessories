using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PcAccessories.Dtos.UsersDto;
using PcAccessories.Entities.Entities;
using PcAccessories.Services.CMS.UserService;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.WebAPI.Controllers.UserAPI
{
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

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromForm]LoginRequestDto request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null) return BadRequest("Tài khoản không tồn tại");

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, true, true);
            if (!result.Succeeded)
            {
                return BadRequest("Đăng nhập không đúng");
            }

            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>()
            {
                new Claim("Email",user.Email),
                new Claim("Name",user.Name),
                new Claim("UserRole", string.Join(";",roles)),
                new Claim("UserName", request.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtTokens:SecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["JwtTokens:Issuer"],
                _config["JwtTokens:Audience"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }

        #endregion
    }
}
