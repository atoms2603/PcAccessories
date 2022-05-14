using PcAccessories.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.Services.CartService
{
    public interface ICartService : IBaseService<Cart>
    {
        Task<Cart> GetByUserIdAsync(Guid userId);
    }
}
