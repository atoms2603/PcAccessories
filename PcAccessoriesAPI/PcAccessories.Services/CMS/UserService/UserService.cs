using Microsoft.EntityFrameworkCore;
using PcAccessories.EFCore.Data;
using PcAccessories.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.Services.CMS.UserService
{
    public class UserService : IUserService
    {
        private readonly PcAccessoriesDbContext _context;
        public UserService(PcAccessoriesDbContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetALL()
        {
           return await _context.Users.ToListAsync();
        }
    }
}
