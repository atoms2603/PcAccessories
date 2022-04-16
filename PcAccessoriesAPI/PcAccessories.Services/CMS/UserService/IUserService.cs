using PcAccessories.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcAccessories.Services.CMS.UserService
{
    public interface IUserService
    {
        IQueryable<User> GetUserQuery();
        Task<User> GetByIdAsync(Guid id);
        Task<User> GetByUsernameAsync(string username);
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByPhoneNumber(string phoneNumber);
    }
}
