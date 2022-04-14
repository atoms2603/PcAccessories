using PcAccessories.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.Services.CMS.ProductService
{
    public interface IProductService
    {
        IQueryable<Product> GetListProductQuery();
    }
}
