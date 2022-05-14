using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.Entities.Entities
{
    public class ProductInCart : BaseEntity
    {
        public Guid ProductInCartId { get; set; }
        public Guid ProductId { get; set; }
        public Guid CartId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
