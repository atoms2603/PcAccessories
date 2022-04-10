using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
    }
}
