using PcAccessories.EFCore.Data;
using PcAccessories.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.Services.BrandService
{
    public class BrandService : BaseService<Brand>, IBrandService
    {
        public BrandService(PcAccessoriesDbContext context) : base(context)
        {

        }
    }
}
