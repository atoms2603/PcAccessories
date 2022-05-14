using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.Dtos.CategoryDto.Response
{
    public class GetListCategoryResponseDto
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public List<Brand> Brands { get; set; } = new List<Brand>();

        public class Brand
        {
            public Guid BrandId { get; set; }
            public string Name { get; set; }
        }
    }
}
