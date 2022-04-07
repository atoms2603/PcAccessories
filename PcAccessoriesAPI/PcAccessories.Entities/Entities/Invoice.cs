using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.Entities.Entities
{
    public class Invoice : BaseEntity
    {
        public Guid InvoiceId { get; set; }
        public Guid UserId { get; set; }
        public string DeliveryName { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryPhone { get; set; }
        public byte Status { get; set; }
        public User User { get; set; }
        public List<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
