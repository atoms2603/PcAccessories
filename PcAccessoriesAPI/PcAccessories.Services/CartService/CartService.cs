using Microsoft.EntityFrameworkCore;
using PcAccessories.EFCore.Data;
using PcAccessories.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.Services.CartService
{
    class CartService : BaseService<Cart>, ICartService
    {
        public CartService(PcAccessoriesDbContext context) : base(context)
        {

        }

        public async Task<Cart> GetByUserIdAsync(Guid userId)
        {
            return await _context.Carts.FirstOrDefaultAsync(x => x.UserId == userId);
        }
    }
}
