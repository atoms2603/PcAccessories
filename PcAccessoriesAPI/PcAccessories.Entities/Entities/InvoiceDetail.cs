using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.Entities.Entities
{
    public class InvoiceDetail : BaseEntity
    {
        public Guid InvoiceDetailId { get; set; }
        public Guid InvoiceId { get; set; }
        public Guid ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Invoice Invoice { get; set; }
        public Product Product { get; set; }
    }
}
