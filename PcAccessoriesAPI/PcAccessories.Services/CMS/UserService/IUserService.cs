using PcAccessories.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PcAccessories.Services.CMS.UserService
{
    public interface IUserService
    {
        Task<User> GetByIdAsync(Guid id);
        Task<User> GetByUsernameAsync(string username);
        Task<User> GetByEmailAsync(string email);
        Task<User> FindByPhoneNumber(string phoneNumber);
    }
}
