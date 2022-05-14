using PcAccessories.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.Services.ProductInCartService
{
    public interface IProductInCartService : IBaseService<ProductInCart>
    {
        Task<ProductInCart> IsProductExistInCartAsync(Guid cartId, Guid productId);
    }
}
