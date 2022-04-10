using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.Entities.Entities
{
    public class ProductImage : BaseEntity
    {
        public Guid ProductImageId { get; set; }
        public Guid ProductId { get; set; }
        public string ImagePath { get; set; }
    }
}
