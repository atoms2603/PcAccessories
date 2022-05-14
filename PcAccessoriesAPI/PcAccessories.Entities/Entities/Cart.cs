using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.Entities.Entities
{
    public class Cart : BaseEntity
    {
        public Guid CartId { get; set; }
        public Guid UserId { get; set; }
    }
}
