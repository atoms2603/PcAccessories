using Microsoft.EntityFrameworkCore;
using PcAccessories.EFCore.Data;
using PcAccessories.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.Services.CMS.ProductService
{
    public class ProductService : IProductService
    {
        private readonly PcAccessoriesDbContext _context;

        public ProductService(PcAccessoriesDbContext context)
        {
            _context = context;
        }

        public IQueryable<Product> GetListProductQuery()
        {
            return  _context.Products.ToList().AsQueryable();
        }
    }
}
