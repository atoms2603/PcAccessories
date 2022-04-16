using Microsoft.EntityFrameworkCore;
using PcAccessories.EFCore.Data;
using PcAccessories.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.Services.ProductService
{
    public class ProductService : BaseService<Product>, IProductService
    {
        public ProductService(PcAccessoriesDbContext context) : base(context)
        {

        }

        public async Task<Product> GetProductById(Guid productId)
        {
            return await _context.Products.Where(x=> x.ProductId.Equals(productId)).FirstOrDefaultAsync();
        }
    }
}
