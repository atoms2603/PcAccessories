using Microsoft.EntityFrameworkCore;
using PcAccessories.EFCore.Data;
using PcAccessories.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.Services.ProductInCartService
{
    public class ProductInCartService : BaseService<ProductInCart>, IProductInCartService
    {
        public ProductInCartService(PcAccessoriesDbContext context) : base(context)
        {

        }

        public async Task<ProductInCart> IsProductExistInCartAsync(Guid cartId, Guid productId)
        {
            return await _context.ProductInCarts.FirstOrDefaultAsync(x => x.CartId == cartId && x.ProductId == productId);
        }
    }
}
