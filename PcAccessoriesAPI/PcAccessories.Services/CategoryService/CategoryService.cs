using PcAccessories.EFCore.Data;
using PcAccessories.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.Services.CategoryService
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        public CategoryService (PcAccessoriesDbContext context) : base(context)
        {

        }
    }
}
