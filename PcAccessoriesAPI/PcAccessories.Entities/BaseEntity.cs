using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatetionTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public Guid CreatetionBy { get; set; }
        public Guid UpdateBy { get; set; }
    }
}
