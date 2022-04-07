using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.Entities.Entities
{
    public class ProductLove : BaseEntity
    {
        public Guid ProductLoveId { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
