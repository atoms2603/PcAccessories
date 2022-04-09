using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PcAccessories.Services.CMS.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcAccessories.WebAPI.Controllers.UserAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Private fields

        private readonly IUserService _userService;

        #endregion

        #region Constructor

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region API Controllers

        [HttpGet]
        public async Task<IActionResult> GetAllUserAsync()
        {
            var listUser = await _userService.GetALL();
            return Ok(listUser);
        }

        #endregion
    }
}
