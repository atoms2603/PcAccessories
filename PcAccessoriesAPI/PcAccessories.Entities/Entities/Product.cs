using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.Entities.Entities
{
    public class Product : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Guid BrandId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public byte Status { get; set; }
        public Brand Brand { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public List<ProductLove> ProductLoves { get; set; }
        public List<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
