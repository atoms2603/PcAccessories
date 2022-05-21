using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.Dtos.InvoiceDto
{
    public class CreateInvoiceRequestDto
    {
        public string DeliveryName { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryPhone { get; set; }

        public List<Product> Products { get; set; }

        public class Product
        {
            public Guid ProductId { get; set; }
            public string ProductName { get; set; }
            public double Price { get; set; }
            public int Quantity { get; set; }
        }
    }
}
