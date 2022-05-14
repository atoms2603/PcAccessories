using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.Dtos.ProductDto.Response
{
    public class ProductDetailDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public double Price { get; set; }
    }
}
