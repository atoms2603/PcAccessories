using Microsoft.EntityFrameworkCore;
using PcAccessories.EFCore.Data;
using PcAccessories.Entities.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PcAccessories.Services.UserService
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(PcAccessoriesDbContext context) : base(context)
        {
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context.Users.Where(x => x.UserName == username).FirstOrDefaultAsync();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
        }

        public async Task<User> GetByPhoneNumber(string phoneNumber)
        {
            return await _context.Users.Where(x => x.PhoneNumber == phoneNumber).FirstOrDefaultAsync();
        }
    }
}
