using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.Entities.Entities
{
    public class Slide : BaseEntity
    {
        public Guid SlideId { get; set; }
        public string Image { get; set; }
        public byte Status { get; set; }
    }
}
