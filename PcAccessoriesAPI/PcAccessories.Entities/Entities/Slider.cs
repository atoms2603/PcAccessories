using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.Entities.Entities
{
    public class Slider : BaseEntity
    {
        public Guid SliderId { get; set; }
        public string Image { get; set; }
    }
}
