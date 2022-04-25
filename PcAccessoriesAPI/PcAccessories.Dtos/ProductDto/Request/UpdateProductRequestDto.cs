using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.Dtos.ProductDto.Request
{
    public class UpdateProductRequestDto
    {
        public Guid ProductId { get; set; }
        public Guid BrandId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public byte Status { get; set; }
    }
}
