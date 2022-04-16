using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PcAccessories.Dtos.Pagination;
using PcAccessories.Dtos.UsersDto.Request;
using PcAccessories.Dtos.UsersDto.Response;
using PcAccessories.Services.CMS.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcAccessories.WebAPI.Controllers.Admin.UserAPI
{
    [Route("admin/api/user")]
    [ApiController]
    public class UserAdminController : ControllerBase
    {

        #region Private fields

        private readonly IUserService _userService;

        #endregion

        #region Constructor

        public UserAdminController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region API Controllers

        [HttpGet]
        public async Task<IActionResult> GetListUser([FromQuery] GetListUserRequestDto request)
        {
            var userQuery = from user in _userService.GetUserQuery()
                               select new GetListUserResponseDto
                               {
                                   UserId = user.Id,
                                   Status = user.Status,
                                   LastLogInTime = user.LastLogInTime,
                                   Name = user.Name,
                                   RoleName = ""
                               };

            if (!string.IsNullOrEmpty(request.Keyword))
                userQuery = userQuery.Where(x => x.Name.Contains(request.Keyword));

            // Count rows
            int totalRowsFound = await userQuery.CountAsync();
            if (totalRowsFound == 0) return Ok(new PagingResult<GetListUserResponseDto>(null, 0, request.PageIndex, request.PageSize));

            // Apply Sort
            userQuery = ApplySort(userQuery, request.SortBy, request.SortOrder);

            // Pagination
            var pageResult = await userQuery.Skip(request.Offset).Take(request.PageSize).ToListAsync();

            return Ok(new PagingResult<GetListUserResponseDto>(pageResult, totalRowsFound, request.PageIndex, request.PageSize));
        }

        #endregion

        #region Private methods

        private IQueryable<GetListUserResponseDto> ApplySort(IQueryable<GetListUserResponseDto> query, string sortColumn, string sortOrder)
        {
            return (sortColumn?.ToLower()) switch
            {
                "name" => "desc" == sortOrder ? query.OrderByDescending(x => x.Name) : query.OrderBy(x => x.Name),
                "lastlogintime" => "desc" == sortOrder ? query.OrderByDescending(x => x.LastLogInTime) : query.OrderBy(x => x.LastLogInTime),
                "status" => "desc" == sortOrder ? query.OrderByDescending(x => x.Status) : query.OrderBy(x => x.Status),
                "rolename" => "desc" == sortOrder ? query.OrderByDescending(x => x.RoleName) : query.OrderBy(x => x.RoleName),
                _ => query.OrderByDescending(x => x.Name),
            };
        }

        #endregion
    }
}
