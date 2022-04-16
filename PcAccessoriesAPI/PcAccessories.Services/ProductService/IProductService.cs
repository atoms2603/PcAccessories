using PcAccessories.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.Services.ProductService
{
    public interface IProductService : IBaseService<Product>
    {
        Task<Product> GetProductById(Guid productId);
    }
}
